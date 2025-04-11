namespace PersonalChef.Api.Models
{
    public class RecipeIngredient
    {
        /// <summary>
        /// Unique identifier for the <see cref="RecipeIngredient"/>
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Amount of the ingredient. Combines with the <see cref="Unit"/> property for context.
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// Unit of the ingredient measurement. Combines with the <see cref="Quantity"/> property for context.
        /// </summary>
        public required string Unit { get; set; }
        /// <summary>
        /// Name of the ingredient used within the recipe.
        /// </summary>
        public required string Ingredient { get; set; }
    }
}
