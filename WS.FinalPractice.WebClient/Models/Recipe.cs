namespace WS.FinalPractice.WebClient.Models
{
    public class Recipe
    {
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
		
		public List<string> Instructions { get; set; }

		public int Servings { get; set; }

		public List<Ingredient> Ingredients { get; set; }

		public int PrepTime { get; set; }

		public int TotalTime { get; set; }
	}
}
