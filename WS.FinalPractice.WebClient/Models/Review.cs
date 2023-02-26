namespace WS.FinalPractice.WebClient.Models
{
    public partial class review
    {

        public string author { get; set; }

        public string comment { get; set; }

        public System.DateTime date { get; set; }

        public bool dateSpecified { get; set; }

        public long id { get; set; }

        public bool idSpecified { get; set; }

        public int rating { get; set; }

        public string recipeId { get; set; }
    }
}
