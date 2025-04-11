using PersonalChef.Api.Models;

namespace PersonalChef.Api.Mappers
{
    public class RecipeIngredientMapper: IMapper<DataModel.Model.RecipeIngredient, RecipeIngredient>
    {
        public RecipeIngredient Map(DataModel.Model.RecipeIngredient source)
        {
            return new RecipeIngredient
            {
                Id = source.Id,
                Quantity = source.Quantity,
                Ingredient = source.Ingredient.Name,
                Unit = source.Unit.Name ?? string.Empty
            };
        }
    }
}