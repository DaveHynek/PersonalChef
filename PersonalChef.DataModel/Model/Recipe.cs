using PersonalChef.Data.Converter;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonalChef.DataModel.Model
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        /// <summary>Name of the <see cref="Recipe"/></summary>
        [Required]
        [StringLength(128)]
        [Display(Name="Recipe Name")]
        public string Name { get; set; }

        /// <summary>Description of the <see cref="Recipe"/></summary>
        [Required]
        [StringLength(512)]
        [Display(Name = "Recipe Description")]
        public string Description { get; set; }

        /// <summary>Image containing the completed <see cref="Recipe"/></summary>
        [Display(Name = "Recipe Image")]
        public byte[] Image { get; set; }

        /// <summary>
        /// Collection of <see cref="RecipeIngredient"/>s associated with the <see cref="Recipe"/>
        /// </summary>
        public virtual List<RecipeIngredient> RecipeIngredients { get; set; }

        /// <summary>
        /// Collection of <see cref="RecipeStep"/>s associated with the <see cref="Recipe"/>
        /// </summary>
        public virtual List<RecipeStep> RecipeSteps { get; set; }
    }
}
