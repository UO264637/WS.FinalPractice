using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WS.FinalPractice.WebClient.Models;

namespace WS.FinalPractice.WebClient.Controllers
{
    public class RecipesController : Controller
    {
        private IConfiguration _configuration;

        public RecipesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IActionResult> Index(string searchParameter)
        {
            Console.WriteLine(HttpContext.Session.GetString("user"));
            var client = new RestClient(
                _configuration.GetValue<string>("WebSettings:AppEndPoint"));
            var request = new RestRequest("recipes", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("searchParameter", searchParameter);
            var response = await client.ExecuteAsync<List<Recipe>>(request);
            if (!response.IsSuccessful) return BadRequest();
            return View(response.Data.ToArray<Recipe>());
        }

        public async Task<IActionResult> Recipe(string id)
        {
            Console.WriteLine(HttpContext.Session.GetString("user"));
            var client = new RestClient(
                _configuration.GetValue<string>("WebSettings:AppEndPoint")+ "recipes");
            var request = new RestRequest("/{id}", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await client.ExecuteAsync<FullRecipe>(request);
            if (!response.IsSuccessful) return BadRequest();
            return View(response.Data);
        }

        public async Task<IActionResult> Review(string recipeId)
        {
            Console.WriteLine(HttpContext.Session.GetString("user"));
            if (HttpContext.Session.GetString("user") == null)
            {
                return Redirect("~/Authentication");
            }

            var review = new review { recipeId= recipeId, author=HttpContext.Session.GetString("user")};

            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> Review(review r)
        {
            if (r.rating < 0 || r.rating > 5)
            {
				ModelState.AddModelError("rating", "Invalid rating");
				return View();
			}

            var token = HttpContext.Session.GetString("token");
            if(token == null) return Redirect("~/Authentication");
            var client = new RestClient(
				_configuration.GetValue<string>("WebSettings:AppEndPoint") + "reviews");
			var request = new RestRequest("", Method.Post);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(JsonConvert.SerializeObject(r));
            request.AddHeader("token", token);
			var response = await client.ExecuteAsync(request);
			if (!response.IsSuccessful) return Redirect("~/Authentication");
            var review = JsonConvert.DeserializeObject<review>(response.Content);
            
            return Redirect("~/Recipes/Recipe?id=" + r.recipeId); 
        }
    }
}
