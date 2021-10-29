using cookbookAPI.Engine.Contract;
using cookbookAPI.Managers.Contract;
using cookbookAPI.Resources.Contract;
using cookbookAPI.Resources.Contract.Model;
using cookbookAPI.Utilities;
using System;
using System.Collections.Generic;

namespace cookbookAPI.Managers
{
    public class RecipesManager : IRecipesManager
    {
        private readonly IRecipeResource recipeResource;
        private readonly IEligibilityEngine eligibilityEngine;

        public RecipesManager(IRecipeResource _recipeResource, IEligibilityEngine _eligibilityEngine)
        {
            recipeResource = _recipeResource;
            eligibilityEngine = _eligibilityEngine;
        }

        public List<Contract.Model.Ingredients> GetIngredientsFromDB()
        {
            return MapObject.MapObjList<Ingredients, Contract.Model.Ingredients>(recipeResource.GetAllIngredients());
        }

        public Contract.Model.RecipeForPost GetRecipeByIdFromDB(Guid id)
        {
            int count=0;
            Contract.Model.Recipe recipeFromDb= MapObject.MapObj<Resources.Contract.Model.Recipe, Contract.Model.Recipe>(recipeResource.GetRecipeById(id));
            Contract.Model.IngredientRecipeModel[] quantities = new Contract.Model.IngredientRecipeModel[recipeFromDb.Quantities.Count];
            Contract.Model.RecipeForPost recipe = MapObject.MapObj<Contract.Model.Recipe, Contract.Model.RecipeForPost>(recipeFromDb);

            foreach (KeyValuePair<int,string> elem in recipeFromDb.Quantities)
            {
                Contract.Model.IngredientRecipeModel ingredientQuantityPair = new Contract.Model.IngredientRecipeModel();

                ingredientQuantityPair.Quantity= elem.Value;
                ingredientQuantityPair.Name = recipeResource.GetIngredientsName(elem.Key);
                quantities[count] = ingredientQuantityPair;
                count++;
            }

            recipe.IngredientsQuantities = quantities;
            return recipe;
        }

        public List<Contract.Model.DtoRecipe> GetRecipesDtoFromDB(int dishType)
        {
            return MapObject.MapObjList<DtoRecipe, Contract.Model.DtoRecipe>(recipeResource.GetRecipesList(dishType));
        }

        public string PostRecipeInDB(Contract.Model.RecipeForPost recipe, string username, string password)
        {
            Contract.Model.User userData = MapObject.MapObj<Engine.Contract.Model.User, Contract.Model.User>(eligibilityEngine.GetUserIfEligible(username, password));

            if ((userData.UserName == username) && (userData.UserRole==1))
            {
                Contract.Model.Recipe dbRecipe = FetchRecipeData(recipe);
                return recipeResource.SaveRecipe(MapObject.MapObj<Contract.Model.Recipe, Resources.Contract.Model.Recipe>(dbRecipe));
            }

            return "Unauthorized Access";
        }

        public Contract.Model.Recipe FetchRecipeData(Contract.Model.RecipeForPost recipe)
        {
            Contract.Model.Recipe dbRecipe = MapObject.MapObj<Contract.Model.RecipeForPost, Contract.Model.Recipe>(recipe);
            dbRecipe.Quantities = new Dictionary<int, string>();

            foreach (Contract.Model.IngredientRecipeModel quantity in recipe.IngredientsQuantities)
            {
                int res = recipeResource.GetIngredientId(quantity.Name);
                dbRecipe.Quantities[res] = quantity.Quantity;
            }

            return dbRecipe;
        }
    }
}
