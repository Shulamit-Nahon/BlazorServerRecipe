using DemoBlazorServerRecipe.Data.Services.Interfaces;
using DemoBlazorServerRecipe.Models.DTO;

namespace DemoBlazorServerRecipe.Data.Services
{
    public class RecipeService : IRecipeService
    {
        public Task<int> AddOrUpdateCountryAsync(CountryDTO countryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCountry(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CountryDTO>> GetCountriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CountryDTO> GetCountryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
