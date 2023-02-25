using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Xml.Linq;
using WS.FinalPractice.Application.Utils;
using WSClient.UsersWS;

namespace WS.FinalPractice.Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
        private IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet("{token}")]
        public ActionResult<String> Get([FromRoute] string token)
        {
            try
            {
                var securityToken = JsonConvert.DeserializeObject<dynamic>(
                AESManager.Decrypt(token));
                if (securityToken == null)
                {
                    return NotFound();
                }
                else if (DateTime.Parse(
                securityToken.ExpirationDate.ToString()) > DateTime.Now)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] dynamic authRequest)
        {
            try
            {
                var credentialsChain = JsonConvert.DeserializeObject<dynamic>(authRequest.ToString()).user.ToString();

                string[] credentials = credentialsChain.Split(':');

                UsersWSClient usersClient = new UsersWSClient(
                UsersWSClient.EndpointConfiguration.UsersWSPort,
                    _configuration.GetValue<string>("ApplicationSettings:UsersEndpoint"));

                if (credentials.Length != 2 || credentials[0] == null || credentials[1] == null) { 
                    Console.WriteLine("Bad Request");
                    return BadRequest();
                }

                var existentUser = usersClient.getUserAsync(credentials[0]).Result.@return;
                if (existentUser == null)
                    return NotFound();
                if (credentials[1] != existentUser.password)
                    return Unauthorized("Wrong Credentials");

                var token = AESManager.Encrypt(JsonConvert.SerializeObject(
                    new { UserName = existentUser.userName, ExpirationDate = DateTime.Now.AddDays(30) }));
                return CreatedAtAction(
                 "Get", new { token = token }, new { Token = token });
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}
