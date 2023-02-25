using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using WS.FinalPractice.Application.Model;
using WSClient.ReviewsWS;

namespace WS.FinalPractice.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private IConfiguration _configuration;
        public RecipesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var client = new RestClient(
                _configuration.GetValue<string>("ApplicationSettings:TastyEndPoint") + "list");
            var getRequest = new RestRequest("", Method.Get);
            getRequest.RequestFormat = DataFormat.Json;
            getRequest.AddParameter("from", "0", ParameterType.QueryString);
            getRequest.AddParameter("size", "20", ParameterType.QueryString);

            getRequest.AddHeader("X-RapidAPI-Key", "fd8cbfe566msh00649ab9da3e67bp11f21ajsna12f9b8f5efb");
            getRequest.AddHeader("X-RapidAPI-Host", "tasty.p.rapidapi.com");

            var response = await client.ExecuteAsync(getRequest);
            if (!response.IsSuccessful)
                return BadRequest();

            var recipesData = JObject.Parse(response.Content);
            var recipeList = new List<Recipe>();
            if (recipesData != null)
            {
                var recipes = recipesData["results"].Children();
                foreach (JToken jToken in recipes)
                {
                    Recipe recipe = ParseBasicRecipe(jToken);

					recipeList.Add(recipe);

					Console.WriteLine(recipe);
                }
                
            }
            return Ok(recipeList);
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<FullRecipe>> GetRecipes([FromRoute] string id)
        {
			var client = new RestClient(
				_configuration.GetValue<string>("ApplicationSettings:TastyEndPoint") + "get-more-info");
			var getRequest = new RestRequest("", Method.Get);
			getRequest.RequestFormat = DataFormat.Json;
			getRequest.AddParameter("id", id, ParameterType.QueryString); //3518

			getRequest.AddHeader("X-RapidAPI-Key", "fd8cbfe566msh00649ab9da3e67bp11f21ajsna12f9b8f5efb");
			getRequest.AddHeader("X-RapidAPI-Host", "tasty.p.rapidapi.com");

			var response = await client.ExecuteAsync(getRequest);
			if (!response.IsSuccessful)
				return BadRequest();
			
			var recipeData = JObject.Parse(response.Content);
			FullRecipe fullRecipe = new FullRecipe();
			if (recipeData != null)
			{
                fullRecipe.recipe = ParseFullRecipe(recipeData);
				fullRecipe = await ParseWithReviewDataAsync(fullRecipe);
            }
			return Ok(fullRecipe);
		}

		private async Task<FullRecipe> ParseWithReviewDataAsync(FullRecipe fullRecipe)
		{
			var reviewsClient = new ReviewsDSClient(ReviewsDSClient.EndpointConfiguration.ReviewsDSPort,
				_configuration.GetValue<string>("ApplicationSettings:ReviewsEndpoint"));
			var reviewsResult = await reviewsClient.getReviewsForRecipeAsync(fullRecipe.recipe.Id);
			fullRecipe.reviews = (reviewsResult.@return != null) ? reviewsResult.@return.ToList() : new List<review>();
			return fullRecipe;
		}

        private Recipe ParseFullRecipe(JToken recipeData)
        {
			Recipe recipe = ParseBasicRecipe(recipeData);

			var instructions = recipeData["instructions"];
			if (instructions != null)
			{
				List<String> instructionsList = new List<String>();
				foreach (JToken instrucion in instructions.Children())
				{
					instructionsList.Add(instrucion["display_text"].ToString());
				}
				recipe.Instructions = instructionsList;
			}

			var sections = recipeData["sections"];
			if (sections != null)
			{
				List<Ingredient> ingredients = new List<Ingredient>();
				foreach (JToken section in sections.Children())
				{
					if (section["name"] == null || section["name"].ToString() != "Special Equipment")
					{
						var ingredientsData = section["components"];
						if (ingredientsData != null)
						{
							foreach (JToken ingredientData in ingredientsData)
							{
								Ingredient ingredient = new Ingredient
								{ Name = ingredientData["ingredient"]["name"].ToString(),
								  Description = ingredientData["raw_text"].ToString()
								};
								ingredients.Add(ingredient);
							}
						}
					}
				}
				recipe.Ingredients = ingredients;
			}

			return recipe;
		}

		private Recipe ParseBasicRecipe(JToken recipeData)
		{
			Recipe recipe = new Recipe
			{
				Id = recipeData["id"].ToString(),
				Name = recipeData["name"].ToString(),
				Description = recipeData["description"].ToString()
			};
			if (recipeData["num_servings"] != null)
			{
				recipe.Servings = Int16.Parse(recipeData["num_servings"].ToString());
			}
			if (recipeData["prep_time_minutes"] != null && recipeData["prep_time_minutes"].ToString() != "")
			{
				recipe.PrepTime = Int16.Parse(recipeData["prep_time_minutes"].ToString());
			}
			if (recipeData["total_time_minutes"] != null && recipeData["total_time_minutes"].ToString() != "")
			{
				recipe.TotalTime = Int16.Parse(recipeData["total_time_minutes"].ToString());
			}

			return recipe;
		}
	}
}
