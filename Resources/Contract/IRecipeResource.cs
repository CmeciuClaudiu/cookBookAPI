using System;
using System.Collections.Generic;

namespace cookbookAPI.Resources.Contract
{
    public interface IRecipeResource
    {
        public string SaveRecipe(Model.Recipe recipe);
        public List<Model.Ingredients> GetAllIngredients();
        public List<Model.DtoRecipe> GetRecipesList(int dishType);
        public Model.Recipe GetRecipeById(Guid Id);
        int GetIngredientId(string name);
        string GetIngredientsName(int id);
    }
}
