using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cookbookAPI.Managers.Contract.Model
{
    public class Recipe
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
        [RegularExpression("([1-9]|[1-9][0-9]|[1-4][0-9][0-9])")]
        public int? PreparationTime { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public Dictionary<int, string> Quantities { get; set; }
    }
}
