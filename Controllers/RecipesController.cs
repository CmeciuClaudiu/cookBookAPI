using cookbookAPI.Managers.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace cookbookAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesManager recipesManager;
        public RecipesController(IRecipesManager _recipesManager)
        {
            recipesManager = _recipesManager;
        }
     
        [HttpGet]
        [Route("ingredients")]
        public List<Managers.Contract.Model.Ingredients> GetIngredients()
        {
            return recipesManager.GetIngredientsFromDB();
        }

        [HttpGet]
        [Route("dtorecipe")]
        public Managers.Contract.Model.DtoRecipe[] GetRecipesDto(int dishType)
        {
            return recipesManager.GetRecipesDtoFromDB(dishType).ToArray();
        }

        [HttpGet]
        [Route("recipe")]
        public Managers.Contract.Model.RecipeForPost GetRecipe(Guid id)
        {
            return recipesManager.GetRecipeByIdFromDB(id);
        }

        [HttpPost]
        [Route("post")]
        public string Post(Managers.Contract.Model.RecipeForPost recipe,string username,string password)
        {
            return recipesManager.PostRecipeInDB(recipe, username, password);
        }

    }
}
