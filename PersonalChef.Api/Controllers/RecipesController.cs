using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalChef.Api.Models;
using PersonalChef.Api.Services;

namespace PersonalChef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IDbContextFactory<RecipeContext> _contextFactory;
        private readonly IRecipeService _recipeService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(RecipesController));

        public RecipesController(IDbContextFactory<RecipeContext> contextFactory, IRecipeService recipeService)
        {
            _contextFactory = contextFactory;
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            //TODO: Move to recipe service
            await using var context = _contextFactory.CreateDbContext();

            return await context.Recipes
                .Select(x => new { Id = x.Id, Name = x.Name, Description = x.Description })
                .ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Recipe> Get(int id)
        {
            return await _recipeService.GetRecipeAsync(id).ConfigureAwait(false);
        }
    }
}
