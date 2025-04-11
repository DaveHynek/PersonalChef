using Microsoft.EntityFrameworkCore;
using PersonalChef.Api.Mappers;
using PersonalChef.Api.Models;

namespace PersonalChef.Api.Services
{
    public class RecipeService: IRecipeService
    {
        private readonly IDbContextFactory<RecipeContext> _contextFactory;
        private readonly IMapper<DataModel.Model.Recipe, Recipe> _recipeMapper;

        public RecipeService(IDbContextFactory<RecipeContext> contextFactory, IMapper<DataModel.Model.Recipe, Recipe> recipeMapper)
        {
            _contextFactory = contextFactory;
            _recipeMapper = recipeMapper;
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var recipe = await context.Recipes
                .Include(x => x.RecipeIngredients).ThenInclude(x => x.Unit)
                .Include(x => x.RecipeIngredients).ThenInclude(x => x.Ingredient)
                .Include(x => x.RecipeSteps)
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);

            if (recipe == null) throw new ArgumentException("The provided ID does not map to a valid recipe.", "id");

            return _recipeMapper.Map(recipe);
        }
    }
}
