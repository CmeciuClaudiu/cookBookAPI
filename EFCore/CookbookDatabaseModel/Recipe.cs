using System.Collections.Generic;

#nullable disable

namespace cookbookAPI
{
    public partial class Recipe
    {
        public Recipe()
        {
            PrepInstructs = new HashSet<PrepInstruct>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public string Id { get; set; }
        public string DishName { get; set; }
        public int DishType { get; set; }
        public string Description { get; set; }
        public int? PreparationTime { get; set; }
        public string Image { get; set; }

        public virtual ICollection<PrepInstruct> PrepInstructs { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
