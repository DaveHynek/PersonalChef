using PersonalChef.Api.Models;

namespace PersonalChef.Api.Mappers
{
    public class RecipeStepMapper : IMapper<DataModel.Model.RecipeStep, RecipeStep>
    {
        public RecipeStep Map(DataModel.Model.RecipeStep source)
        {
            return new RecipeStep
            {
                Id = source.Id,
                Text = source.Text,
                Order = source.Order
            };
        }
    }
}
