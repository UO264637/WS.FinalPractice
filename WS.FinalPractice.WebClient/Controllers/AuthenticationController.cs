using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Newtonsoft.Json;
using RestSharp;
using WS.FinalPractice.WebClient.Models;

namespace WS.FinalPractice.WebClient.Controllers
{
    public class AuthenticationController : Controller
    {
        private IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginData loginData)
        {
            var client = new RestClient(
                _configuration.GetValue<string>("WebSettings:AppEndPoint") + "authentication");
            var request = new RestRequest("", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody("{\"user\":\""+loginData.UserName + ':' + loginData.Password + "\"}");
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("Password", "Invalid Credentials");
                return View();
            }
			var contentDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
			string token = contentDictionary["token"];

            HttpContext.Session.SetString("user", loginData.UserName);
            HttpContext.Session.SetString("token", token);

            return Redirect("~/Home");
        }
    }
}
