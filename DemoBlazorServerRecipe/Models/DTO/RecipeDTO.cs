using DemoBlazorServerRecipe.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoBlazorServerRecipe.Models.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        [Required, Display(Name = "Recipe Name")]
        public string RecipeName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public int Rank { get; set; }
        [Required, DataType(DataType.Time)]
        public TimeOnly GeneralTImeNeeded { get; set; } = TimeOnly.MinValue;
        [Required, Display(Name = "Image")]
        public string GeneralImage { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        [JsonIgnore]
        public List<Step>? Procedures { get; set; }
        public Country? Country { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
