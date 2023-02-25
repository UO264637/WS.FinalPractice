using Microsoft.AspNetCore.Mvc;
using WSClient.ReviewsWS;

namespace WS.FinalPractice.Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private IConfiguration _configuration;
		public ReviewsController(IConfiguration configuration)
		{
			this._configuration = configuration;
		}

		// GET for recipe
		[HttpGet]
		public async Task<ActionResult<List<review>>> GetReviewsForRecipe([FromQuery] string recipeId)
		{
			var reviewsClient = new ReviewsDSClient(ReviewsDSClient.EndpointConfiguration.ReviewsDSPort,
				_configuration.GetValue<string>("ApplicationSettings:ReviewsEndpoint"));
			var reviews = await reviewsClient.getReviewsForRecipeAsync(recipeId);
			if (reviews.@return == null) return new List<review>();
			return reviews.@return.ToList();
		}

		// POST
		[HttpPost]
		public async Task<ActionResult<review>> PostReview([FromBody] review review)
		{
			var reviewsClient = new ReviewsDSClient(ReviewsDSClient.EndpointConfiguration.ReviewsDSPort,
				_configuration.GetValue<string>("ApplicationSettings:ReviewsEndpoint"));
			var result = await reviewsClient.createRecipeReviewAsync(review.comment, review.author, review.recipeId, review.rating);
			if (result == null)
			{
				return BadRequest();
			}
			return CreatedAtRoute(new { id = result.@return.id }, review);
		}

		// DELETE
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<review>>> DeleteReview([FromRoute] long id)
		{
			var reviewsClient = new ReviewsDSClient(ReviewsDSClient.EndpointConfiguration.ReviewsDSPort,
				_configuration.GetValue<string>("ApplicationSettings:ReviewsEndpoint"));
			var reviewToDelete = await reviewsClient.getReviewByIdAsync(id);
			if (reviewToDelete == null) return NotFound();
			await reviewsClient.deleteRecipeReviewAsync(id);
			return Ok("Deleted review " + id);
		}


	}
}
