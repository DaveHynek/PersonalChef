namespace PersonalChef.Api.Models
{
    public class Recipe
    {
        /// <summary>
        /// Unique identifier for the <see cref="Recipe"/>.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the <see cref="Recipe"/>
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Description of the <see cref="Recipe"/>.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Collection of <see cref="RecipeIngredient"/>s associated with the <see cref="Recipe"/>.
        /// </summary>
        public required List<RecipeIngredient> Ingredients { get; set; }
        /// <summary>
        /// Collection of <see cref="RecipeStep"/>s associated with the <see cref="Recipe"/>.
        /// </summary>
        public required List<RecipeStep> Steps { get; set; }
    }
}
