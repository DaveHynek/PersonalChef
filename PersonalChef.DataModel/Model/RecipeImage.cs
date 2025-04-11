using PersonalChef.DataModel.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonalChef.ApiModel.Model
{
    public class RecipeImage
    {
        /// <summary>
        /// Unique identifier of this record.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The image data for the completed <see cref="Recipe"/>
        /// </summary>
        public byte[] ImageBytes { get; set; }

        /// <summary>
        /// Recipe that the step is included in.
        /// </summary>
        [Required]
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
    }
}
