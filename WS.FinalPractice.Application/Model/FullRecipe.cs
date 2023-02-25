using WSClient.ReviewsWS;

namespace WS.FinalPractice.Application.Model
{
	public class FullRecipe
	{
		public Recipe recipe { get; set; }

		public List<review> reviews { get; set; }

		public double getAverageRating()
		{
			double ratingSum = reviews.Aggregate(0, (accum, x) => accum + x.rating);

			return ratingSum/reviews.Count();
		}
	}
}
