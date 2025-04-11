using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PersonalChef.Data.Converter;

namespace PersonalChef.DataModel.Model
{
    public class RecipeIngredient
    {
        [Key]
        public int Id { get; set; }

        /// <summary>Amount of the ingredient.  Combines with the <see cref="Unit"/> property for context.</summary>
        [Required]
        public double Quantity { get; set; }

        /// <summary>Unit of the ingredient measurement.  Combines with the <see cref="Quantity"/> property for context.</summary>
        [Required]
        [JsonConverter(typeof(MeasurementUnitJsonConverter))]
        public virtual MeasurementUnit Unit { get; set; }

        /// <summary>Ingredient that is included in the recipe.</summary>
        [Required]
        [JsonConverter(typeof(IngredientJsonConverter))]
        public virtual Ingredient Ingredient { get; set; }

        /// <summary>Recipe that the ingredient is a component of.</summary>
        //[Required]
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
        
    }
}
