#nullable disable


namespace cookbookAPI
{
    public partial class PrepInstruct
    {
        public string Id { get; set; }
        public string Instructions { get; set; }
        public string RecipesId { get; set; }

        public virtual Recipe Recipes { get; set; }
    }
}
