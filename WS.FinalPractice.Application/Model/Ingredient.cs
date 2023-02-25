namespace WS.FinalPractice.Application.Model
{
	public class Ingredient
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public List<Store> Stores { get; set; }
	}
}
