using AutoMapper;
using DemoBlazorServerRecipe.Models.DTO;
using DemoBlazorServerRecipe.Models.Entities;

namespace DemoBlazorServerRecipe.Data.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //from database - user
            CreateMap<Country, CountryDTO>();
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<Step, StepDTO>();

            //from user - database
            CreateMap<CountryDTO, Country>();
            CreateMap<RecipeDTO, Recipe>();
            CreateMap<StepDTO,Step>();
        }
    }
}
