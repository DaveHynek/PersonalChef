namespace PersonalChef.Api.Models
{
    public class RecipeStep
    {
        /// <summary>
        /// Unique identifier for the <see cref="RecipeStep"/>
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Primary text instruction for the <see cref="RecipeStep"/>
        /// </summary>
        public required string Text { get; set; }
        /// <summary>
        /// Numeric order of the <see cref="RecipeStep"/> in the <see cref="Recipe"/>.
        /// Lower numbers are earlier in the process.
        /// </summary>
        public int Order { get; set; }
    }
}
