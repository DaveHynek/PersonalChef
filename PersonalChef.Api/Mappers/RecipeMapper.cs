using PersonalChef.Api.Models;

namespace PersonalChef.Api.Mappers
{
    public class RecipeMapper: IMapper<DataModel.Model.Recipe, Recipe>
    {
        private readonly IMapper<DataModel.Model.RecipeIngredient, RecipeIngredient> _recipeIngredientMapper;
        private readonly IMapper<DataModel.Model.RecipeStep, RecipeStep> _recipeStepMapper;

        public RecipeMapper(IMapper<DataModel.Model.RecipeIngredient, RecipeIngredient> recipeIngredientMapper,
            IMapper<DataModel.Model.RecipeStep, RecipeStep> recipeStepMapper)
        {
            _recipeIngredientMapper = recipeIngredientMapper;
            _recipeStepMapper = recipeStepMapper;
        }
        public Recipe Map(DataModel.Model.Recipe source)
        {
            return new Recipe
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Ingredients = source.RecipeIngredients.Select(x => _recipeIngredientMapper.Map(x)).ToList(),
                Steps = source.RecipeSteps.Select(x => _recipeStepMapper.Map(x)).ToList()
            };
        }
    }
}
