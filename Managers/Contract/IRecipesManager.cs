using System;
using System.Collections.Generic;

namespace cookbookAPI.Managers.Contract
{
    public interface IRecipesManager
    {
        List<Model.Ingredients> GetIngredientsFromDB();
        List<Model.DtoRecipe> GetRecipesDtoFromDB(int dishType);
        Model.RecipeForPost GetRecipeByIdFromDB(Guid id);
        string PostRecipeInDB(Model.RecipeForPost recipe, string username, string password);
    }
}
