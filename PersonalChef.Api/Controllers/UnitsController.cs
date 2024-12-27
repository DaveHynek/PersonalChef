using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonalChef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IDbContextFactory<RecipeContext> _contextFactory;

        public UnitsController(IDbContextFactory<RecipeContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await using var context = _contextFactory.CreateDbContext();

            return await context.MeasurementUnits
                .Select(x => x.DisplayName)
                .OfType<string>()
                .ToListAsync();
        }
    }
}
