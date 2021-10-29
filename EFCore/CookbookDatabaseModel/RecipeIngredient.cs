#nullable disable

namespace cookbookAPI
{
    public partial class RecipeIngredient
    {
        public string Id { get; set; }
        public string Quantity { get; set; }
        public int IngredientsId { get; set; }
        public string RecipesId { get; set; }

        public virtual Ingredient Ingredients { get; set; }
        public virtual Recipe Recipes { get; set; }
    }
}
