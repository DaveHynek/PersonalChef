using PersonalChef.ApiModel.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PersonalChef.ApiModel.Common;
using System.Reflection;
using System.ComponentModel;
using System.Linq;

namespace PersonalChef.Data.Converter
{
    public class IngredientJsonConverter : JsonConverter<Ingredient>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Ingredient);
        }

        public override Ingredient Read(ref Utf8JsonReader reader, Type objectType, JsonSerializerOptions serializer)
        {
            return new Ingredient
            {
                Name = reader.GetString()
            };
        }

        public override void Write(Utf8JsonWriter writer, Ingredient value, JsonSerializerOptions serializer)
        {
            writer.WriteStringValue(value.Name);
        }
    }
}
