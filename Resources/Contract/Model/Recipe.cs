using System;
using System.Collections.Generic;

namespace cookbookAPI.Resources.Contract.Model
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public int DishType { get; set; }
        public int? PreparationTime { get; set; }
        public string Image { get; set; }
        public string Instructions { get; set; }
        public Dictionary<int,string> Quantities { get; set; }
    }
}
