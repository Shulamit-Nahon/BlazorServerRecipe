using DemoBlazorServerRecipe.Models.DTO;

namespace DemoBlazorServerRecipe.Data.Services.Interfaces
{
    public interface IRecipeService
    {
        // Country Methods
        Task<int> AddOrUpdateCountryAsync(CountryDTO countryDTO);
        Task<CountryDTO> GetCountryByIdAsync(int id);
        Task<List<CountryDTO>> GetCountriesAsync();
        Task<int> DeleteCountryAsync(int id);

        // Recipe Methods
        Task<int> AddOrUpdateRecipeAsync(RecipeDTO recipeDTO);
        Task<RecipeDTO> GetRecipeByIdAsync(int id);
        Task<List<RecipeDTO>> GetRecipesByCountryIdAsync(int countryId);
        Task<List<RecipeDTO>> GetRecipesAsync();
        Task<int> DeleteRecipeAsync(int id);


        // Procedures Methods
        Task<int> AddOrUpdateStepAsync(StepDTO stepDTO);
        Task<StepDTO> GetStepByIdAsync(int id);
        Task<List<StepDTO>> GetStepByRecipeIdAsync(int recipeId);
        Task<List<StepDTO>> GetStepsAsync();
        Task<int> DeleteStepAsync(int id);
    }
}
