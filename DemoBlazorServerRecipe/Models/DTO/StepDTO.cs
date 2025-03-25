using DemoBlazorServerRecipe.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DemoBlazorServerRecipe.Models.DTO
{
    public class StepDTO
    {
        public int Id { get; set; }
        [Required, Display(Name = "Procedure Number")]
        public int ProcedureNumber { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required, DataType(DataType.Time), Display(Name =" Time Nedded")]
        public TimeOnly TimeNeeded { get; set; }
        public Recipe? Recipe { get; set; }
        [Required]
        public int RecipeId { get; set; }
    }
}
