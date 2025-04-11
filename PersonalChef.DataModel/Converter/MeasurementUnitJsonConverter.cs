using System;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using PersonalChef.DataModel.Model;
using PersonalChef.DataModel.Common;

namespace PersonalChef.Data.Converter
{
    public class MeasurementUnitJsonConverter : JsonConverter<MeasurementUnit>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MeasurementUnit);
        }

        public override MeasurementUnit? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var description = reader.GetString();

            foreach (var val in Enum.GetValues(typeof(Units)).Cast<Units>())
            {
                if (typeof(Units).GetMember((val).ToString()).FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description == description)
                {
                    return new MeasurementUnit(val);
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, MeasurementUnit value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.DisplayName);
        }
    }
}
