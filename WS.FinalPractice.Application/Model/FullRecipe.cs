using WSClient.ReviewsWS;

namespace WS.FinalPractice.Application.Model
{
	public class FullRecipe
	{
		private Recipe recipe { get; set; }

		private List<review> reviews { get; set; }

		public double getAverageRating()
		{
			double ratingSum = reviews.Aggregate(0, (accum, x) => accum + x.rating);

			return ratingSum/reviews.Count();
		}
	}
}
