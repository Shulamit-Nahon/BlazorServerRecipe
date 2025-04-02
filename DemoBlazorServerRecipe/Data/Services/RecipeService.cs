using AutoMapper;
using DemoBlazorServerRecipe.Data.Services.Interfaces;
using DemoBlazorServerRecipe.Models.DTO;
using DemoBlazorServerRecipe.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DemoBlazorServerRecipe.Data.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public RecipeService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        #region Countries methods
        public async Task<int> AddOrUpdateCountryAsync(CountryDTO countryDTO)
        {
            if (countryDTO == null) 
                return (int)HttpStatusCode.BadRequest;

            var country = mapper.Map<Country>(countryDTO);

            //update existing country
            if (countryDTO.Id != 0)
            {
                var findCountry = await appDbContext.Countries.FindAsync(countryDTO.Id);

                if(findCountry is null)
                    return (int)HttpStatusCode.NotFound;

                if (findCountry.CountryName == countryDTO.CountryName && findCountry.Image == countryDTO.Image)
                    return (int)HttpStatusCode.NotImplemented;

                findCountry.CountryName = countryDTO.CountryName;
                findCountry.Image = countryDTO.Image;
                await appDbContext.SaveChangesAsync();
                return (int)HttpStatusCode.OK;

            }

            var chk = await appDbContext.Countries.Where(c => c.CountryName.ToLower().Equals(countryDTO.CountryName.ToLower())).FirstOrDefaultAsync();
            if (chk is not null)
                return (int)HttpStatusCode.NotAcceptable;

            appDbContext.Countries.Add(chk);
            await appDbContext.SaveChangesAsync();
            return (int)HttpStatusCode.Created;
        }

        public async Task<int> DeleteCountryAsync(int id)
        {
            Country? country = await appDbContext.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country is null)
                return (int)HttpStatusCode.NotFound;

            appDbContext.Countries.Remove(country);
            await appDbContext.SaveChangesAsync();
            return (int)HttpStatusCode.OK;
        }

        public async Task<List<CountryDTO>> GetCountriesAsync()
        {
            var countries = await appDbContext.Countries.ToListAsync();
            if (countries is null)
                return null!;

            var countryDTOList = countries.Select(mapper.Map<CountryDTO>);
            return countryDTOList.ToList();


        }

        public async Task<CountryDTO> GetCountryByIdAsync(int id)
        {
            var country = await appDbContext.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country is null)
                return null!;

            var countryDTO = mapper.Map<CountryDTO>(country);
            return countryDTO;
        }
        #endregion

        #region Recipe Methods
        public async Task<int> AddOrUpdateRecipeAsync(RecipeDTO recipeDTO)
        {
            if (recipeDTO is null)
                return (int)HttpStatusCode.BadRequest;

            var recipe = mapper.Map<Recipe>(recipeDTO);

            if (recipeDTO.Id != 0)
            {
                var findRecipe = await appDbContext.Recipes.FindAsync(recipeDTO.Id);
                if (findRecipe is null)
                    return (int)HttpStatusCode.NotFound;

                findRecipe.RecipeName = recipeDTO.RecipeName;
                findRecipe.Rank = recipeDTO.Rank;
                findRecipe.GeneralTImeNeeded = recipeDTO.GeneralTImeNeeded;
                findRecipe.CountryId = recipeDTO.CountryId;
                findRecipe.Description = recipeDTO.Description;
                findRecipe.GeneralImage = recipeDTO.GeneralImage;

                await appDbContext.SaveChangesAsync();
                return (int)HttpStatusCode.OK;
            }

            var chk = await appDbContext.Recipes
                .Where(recipe => recipe.RecipeName.ToLower().Equals(recipeDTO.RecipeName.ToLower()))
                .FirstOrDefaultAsync();
            if ( chk is null)
                return (int)HttpStatusCode.NotAcceptable;

            appDbContext.Add(recipe);
            await appDbContext.SaveChangesAsync();
            return (int)HttpStatusCode.OK;
        }

        public async Task<int> DeleteRecipeAsync(int id)
        {
            var recipe = await appDbContext.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == id);

            if (recipe is null)
                return (int)HttpStatusCode.NotFound;

            appDbContext.Remove(recipe);
            await appDbContext.SaveChangesAsync();
            return (int)HttpStatusCode.OK;


        }

        public async Task<RecipeDTO> GetRecipeByIdAsync(int id)
        {
            var recipe = await appDbContext.Recipes
                .Include(recipe => recipe.Country)
                .Include(recipe => recipe.Procedures)
                .FirstOrDefaultAsync(recipe => recipe.Id == id);

            if (recipe is null)
                return null!;

            var recipeDTO = mapper.Map<RecipeDTO>(recipe);
            return recipeDTO;
        }

        public async Task<List<RecipeDTO>> GetRecipesAsync()
        {
            var recipes = await appDbContext.Recipes.ToListAsync();
            if (recipes is null)
                return null!;

            var recipesDTO = recipes.Select(mapper.Map<RecipeDTO>);
            return recipesDTO.ToList();
        }

        public async Task<List<RecipeDTO>> GetRecipesByCountryIdAsync(int countryId)
        {
            var recipes =  appDbContext.Recipes.Where(recipe => recipe.CountryId == countryId);
            if (recipes is null)
                return null!;

            var recipesDTO = recipes.Select(mapper.Map<RecipeDTO>);
            return recipesDTO.ToList();
        }
        #endregion

        #region Step Methods
        public Task<int> AddOrUpdateStepAsync(StepDTO stepDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteStepAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StepDTO> GetStepByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StepDTO>> GetStepByRecipeIdAsync(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<StepDTO>> GetStepsAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
