using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WS.FinalPractice.WebClient.Models;

namespace WS.FinalPractice.WebClient.Controllers
{
    public class IngredientsController : Controller
    {
        private IConfiguration _configuration;

        public IngredientsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IActionResult> Index(string ingredient="")
        {
            var ing = new Ingredient { Name = ingredient };
            return View(ing);
        }

        public async Task<IActionResult> Ingredient(string ingredient, string zipCode = "")
        {
            if (zipCode == "")
            {
				ModelState.AddModelError("zipCode", "Introduce a value");
				return Redirect("~/Ingredients");
			}
			if (zipCode.Length != 8)
			{
				ModelState.AddModelError("zipCode", "The zip code is composed of 8 alphanumeric characters");
				return Redirect("~/Ingredients");
			}
			var client = new RestClient(
                _configuration.GetValue<string>("WebSettings:AppEndPoint"));
            var request = new RestRequest("kroger", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("ingredientName", ingredient);
            request.AddQueryParameter("zipCode", zipCode);
            var response = await client.ExecuteAsync<Ingredient>(request);
            if (!response.IsSuccessful) return BadRequest();
            return View(response.Data);
        }
    }
}
