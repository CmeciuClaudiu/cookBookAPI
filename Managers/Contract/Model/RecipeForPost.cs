﻿using System;
using System.ComponentModel.DataAnnotations;

namespace cookbookAPI.Managers.Contract.Model
{
    public class RecipeForPost
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DishName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 5)]
        public int DishType { get; set; }

        [Required]
        public int? PreparationTime { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public IngredientRecipeModel[] IngredientsQuantities { get; set; }
    }
}
