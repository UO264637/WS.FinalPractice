using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WS.FinalPractice.Application.Model;

namespace WS.FinalPractice.Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KrogerController : ControllerBase
	{
		private IConfiguration _configuration;
		public KrogerController(IConfiguration configuration)
		{
			this._configuration = configuration;
		}

		[HttpGet]
		public async Task<ActionResult<Ingredient>> GetIngredientPriceAndStores([FromQuery] string ingredientName, [FromQuery] string zipCode)
		{
			var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:KrogerEndpoint"));
			// GET TOKEN FOR SUBSEQUENT REQUESTS
			var tokenRequest = new RestRequest("connect/oauth2/token", Method.Post);
			tokenRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			tokenRequest.AddHeader("Authorization", "Basic dGVzdGFwcHdzdW5pb3ZpMjMtMmU1ODA0MTU4NmU1YWZjMDFmZWNkZWM2NGI3NGQzYmI1NTYyMDg3Mzc3NTc3NjkxMzc4OlNLaHIxWWFRYmc3N3hiMmJzc3I3cHF2eVgyaGtjR0hicGdBUHdITkQ=");
			tokenRequest.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&scope=product.compact", ParameterType.RequestBody);
			var response = await client.ExecuteAsync(tokenRequest);
			if (!response.IsSuccessful)
			{
				return Unauthorized();
			}
			var contentDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
			string access_token = contentDictionary["access_token"];

			// GET THE STORES' DATA
			var storesRequest = new RestRequest("locations", Method.Get);
			storesRequest.AddQueryParameter("filter.limit", 1);
			storesRequest.AddHeader("Authorization", "Bearer " + access_token);
			response = await client.ExecuteAsync(storesRequest);
			if (!response.IsSuccessful)
			{
				return BadRequest();
			}
			var stores = JObject.Parse(response.Content)["data"];
			if (stores.Count() == 0)
			{
				return NotFound("There does not exist any store near the selected location");
			}
			var storesData = stores.Children().First();
			var locationId = storesData["locationId"].ToString();
			var chain = storesData["chain"].ToString();
			var name = storesData["name"].ToString();
			var fullAddressObject = storesData["address"];
			var fullAddress = 
				fullAddressObject["addressLine1"] + ". " + 
				fullAddressObject["city"] + ", " +
				fullAddressObject["county"] + ". " +
				fullAddressObject["state"] + " - " +
				fullAddressObject["zipCode"];

			// GET THE INGREDIENT DATA
			var ingredientNameArray = ingredientName.Split(" ");
			if (ingredientNameArray.Length > 8)
			{
				ingredientName = string.Join(" ", ingredientNameArray, 0, 7); // in Kroger, product queries must have at most 8 terms
			}
			var productsRequest = new RestRequest("products", Method.Get);
			productsRequest.AddQueryParameter("filter.term", ingredientName);
			productsRequest.AddQueryParameter("filter.locationId", locationId);
			productsRequest.AddHeader("Authorization", "Bearer " + access_token);
			response = await client.ExecuteAsync(productsRequest);
			if (!response.IsSuccessful)
			{
				return BadRequest();
			}
			var products = JObject.Parse(response.Content)["data"];
			if (products.Count() == 0)
			{
				return NotFound("There does not exist any product matching this query at the selected location");
			}
			var productData = products.Children().First();

			List<Store> storesList = new List<Store>();
			storesList.Add(new Store { Id = locationId, Chain = chain, Name = name, Address = fullAddress });

			Ingredient ingredient = new Ingredient {
				Price = double.Parse(productData["items"].Children().First()["price"]["regular"].ToString()),
				Stores = storesList

			};

			// RETURN THE INGREDIENT WITH ONLY THE REQUIRED INFORMATION
			return Ok(ingredient);
		}


	}
}
