using cookbookAPI.Resources.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using cookbookAPI.Utilities;

namespace cookbookAPI.Resources
{
    public class RecipeResource : IRecipeResource
    {
        private readonly CookbookDatabaseContext context;
        public RecipeResource(CookbookDatabaseContext _context){
            context = _context;
        }

        public List<Contract.Model.Ingredients> GetAllIngredients()
        {
            return context.Ingredients.Select(c => new Contract.Model.Ingredients
                                      {
                                            ID = c.Id,
                                            Name = c.Name
                                      })
                                      .ToList();
        }

        public List<Contract.Model.DtoRecipe> GetRecipesList(int dishType)
        {
            return context.Recipes.Where(s => s.DishType==dishType)
                                               .Select(c => new Contract.Model.DtoRecipe
                                                        { Id = c.Id,
                                                          DishName=c.DishName,
                                                          Image=c.Image })
                                               .ToList();                            
        }

        public Contract.Model.Recipe GetRecipeById(Guid Id)
        {
            var recipeQueryResult = context.Recipes.Find(Id.ToString());

            if (recipeQueryResult == null)
                return new Contract.Model.Recipe();

            var instructionsQueryResult = context.PrepInstructs.Where(i => i.RecipesId == recipeQueryResult.Id)
                                                                            .Select(i => i.Instructions).FirstOrDefault();

            var quantitiesQueryResult = context.RecipeIngredients.Where(c => c.RecipesId.Contains(recipeQueryResult.Id))
                                                                              .ToDictionary(d => d.IngredientsId, d => d.Quantity);

            Contract.Model.Recipe result = MapObject.MapObj<Recipe, Contract.Model.Recipe>(recipeQueryResult);
            result.Id = new Guid(recipeQueryResult.Id);
            result.Instructions = instructionsQueryResult;
            result.Quantities = quantitiesQueryResult;

            return result;
        }

        public string SaveRecipe (Contract.Model.Recipe recipe)   
        {
            Recipe recipeDbObject=new Recipe();
            recipeDbObject.Id = Guid.NewGuid().ToString();
            recipeDbObject.DishName = recipe.DishName;
            recipeDbObject.DishType = recipe.DishType;
            recipeDbObject.Description = recipe.Description;
            recipeDbObject.Image = recipe.Image;
            recipeDbObject.PreparationTime = recipe.PreparationTime;

            context.Recipes.Add(recipeDbObject);
            context.SaveChanges();

            PrepInstruct instrDbObject=new PrepInstruct();
            instrDbObject.Id = Guid.NewGuid().ToString();
            instrDbObject.Instructions = recipe.Instructions;
            instrDbObject.RecipesId = recipeDbObject.Id;

            context.PrepInstructs.Add(instrDbObject);
            context.SaveChanges();

            foreach (KeyValuePair<int, string> quantities in recipe.Quantities)
            {
                RecipeIngredient recipeIngredientDbObject = new RecipeIngredient();
                recipeIngredientDbObject.Id = Guid.NewGuid().ToString();
                recipeIngredientDbObject.RecipesId = recipeDbObject.Id;
                recipeIngredientDbObject.IngredientsId = quantities.Key;
                recipeIngredientDbObject.Quantity = quantities.Value;

                context.RecipeIngredients.Add(recipeIngredientDbObject);
                context.SaveChanges();
            }

            return recipeDbObject.DishName+" has been succesfully added!";
        }

        public int GetIngredientId(string name)
        {
            return (int)(context.Ingredients.FirstOrDefault(result => result.Name == name)?.Id);
        }

        public string GetIngredientsName(int id)
        {
            return context.Ingredients.FirstOrDefault(result => result.Id == id)?.Name;
        }
    }
}
