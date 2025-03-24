using System.Text.Json.Serialization;

namespace DemoBlazorServerRecipe.Models.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rank { get; set; }
        public TimeOnly GeneralTImeNeeded { get; set; } = TimeOnly.MinValue;
        public string GeneralImage { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        [JsonIgnore]
        public List<Step>? Procedures { get; set; }
        public Country? Country { get; set; }
        public int CountryId { get; set; }

    }
}