using PersonalChef.Api.Models;

namespace PersonalChef.Api.Services
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeAsync(int id);
    }
}