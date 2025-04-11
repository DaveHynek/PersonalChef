using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalChef.DataModel.Common
{
    public enum Units
    {
        // Volume
        [Description("c")]
        [Display(Name = "cup", ShortName = "c")]
        Cup = 1,
        [Description("pt")]
        Pint = 2,
        [Description("qt")]
        Quart = 3,
        [Description("g")]
        Gallon = 4,
        [Description("ml")]
        Milliliter = 5,
        [Description("l")]
        Liter = 6,
        [Description("tsp")]
        Teaspoon = 7,
        [Description("tbsp")]
        Tablespoon = 8,
        [Description("fl oz")]
        FluidOunce = 9,
        // Mass
        [Description("lb")]
        Pound = 10,
        [Description("oz")]
        Ounce = 11,
        [Description("mg")]
        Milligram = 12,
        [Description("g")]
        Gram = 13,
        [Description("kg")]
        Kilogram = 14,
        // Length
        [Description("mm")]
        Millimeter = 15,
        [Description("cm")]
        Centimeter = 16,
        [Description("m")]
        Meter = 17,
        [Description("in")]
        Inch = 18,
        // Amount
        [Description("")]
        Object = 19,
        [Description("clove")]
        Clove = 20
    }
}
