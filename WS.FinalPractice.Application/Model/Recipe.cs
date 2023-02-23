namespace WS.FinalPractice.Application.Model
{
    public class Recipe
    {
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
		
		public List<string> Instructions { get; set; }

		public int Servings { get; set; }

		public List<Ingredient> Ingredients { get; set; }

		public int prepTime { get; set; }

		public int totalTime { get; set; }
	}
}
