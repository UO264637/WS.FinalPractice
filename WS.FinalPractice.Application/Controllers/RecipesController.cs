using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Xml.Linq;
using WS.FinalPractice.Application.Model;

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
            getRequest.AddParameter("size", "50", ParameterType.QueryString);

            getRequest.AddHeader("X-RapidAPI-Key", "fd8cbfe566msh00649ab9da3e67bp11f21ajsna12f9b8f5efb");
            getRequest.AddHeader("X-RapidAPI-Host", "tasty.p.rapidapi.com");

            var response = await client.ExecuteAsync(getRequest);
            if (!response.IsSuccessful)
                return BadRequest();
            //Console.WriteLine(response.Content);
            //var recipes = JsonConvert.DeserializeObject<List<Recipe>>(response.Content.se);
            var recipesData = JObject.Parse(response.Content);
            var recipeList = new List<Recipe>();
            if (recipesData != null)
            {
                var recipes = recipesData["results"].Children();
                foreach (JToken jToken in recipes)
                {
                    recipeList.Add(new Recipe { Name= jToken["name"].ToString() });
                    Console.WriteLine(jToken["name"]);
                }
                
            }
            return Ok(recipeList);
        }
    }
}
