using Microsoft.AspNetCore.Mvc;
using WSClient.UsersWS;

namespace WS.FinalPractice.Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IConfiguration _configuration;
		public UsersController(IConfiguration configuration)
		{
			this._configuration = configuration;
		}

		[HttpGet]
		public async Task<ActionResult<user>> getUsers([FromQuery] string userName)
		{
			UsersWSClient usersClient = new UsersWSClient(
			UsersWSClient.EndpointConfiguration.UsersWSPort,
			_configuration.GetValue<string>("ApplicationSettings:UsersEndpoint"));
			var searchResult = await usersClient.getUserAsync(userName);
			if (searchResult == null)
				return NotFound();
			return Ok(searchResult.@return);
		}
	}
}
