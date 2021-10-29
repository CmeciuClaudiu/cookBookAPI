using System.ComponentModel.DataAnnotations;

namespace cookbookAPI.Managers.Contract.Model
{
    public class DtoRecipe
    {
        public string Id { get; set; }
        public string DishName { get; set; }
        public string Image { get; set; }
    }
}
