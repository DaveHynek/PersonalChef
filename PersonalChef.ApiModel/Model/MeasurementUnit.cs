using PersonalChef.ApiModel.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace PersonalChef.ApiModel.Model
{
    public class MeasurementUnit
    {
        private int _unitId;

        /// <summary>
        /// Create a <see cref="MeasurementUnit"/> from a <see cref="Units"/>.
        /// </summary>
        public MeasurementUnit()
        {
        }

        /// <summary>
        /// Create a <see cref="MeasurementUnit"/> from a <see cref="Units"/>.
        /// </summary>
        /// <param name="unit">Unit to convert to a <see cref="MeasurementUnit"/> data object.</param>
        public MeasurementUnit(Units unit)
        {
            UnitId = (int)unit;
            Name = Enum.GetName(typeof(Units), unit);
        }

        /// <summary>Readonly unit ID, based on the <see cref="Units"/> enum.</summary>
        [Key]
        [Column("Id")]
        public int UnitId {
            get => _unitId;
            protected set
            {
                if (_unitId == value) return;

                _unitId = value;
                Name = Enum.GetName(typeof(Units), value);
            }
        }

        /// <summary>Readonly name of the unit, used for providing context in the database table.</summary>
        [Required]
        [Display(Name = "Unit Name")]
        [StringLength(50)]
        public string? Name { get; protected set; }

        /// <summary>Readonly display name of the unit.</summary>
        [NotMapped]
        public string? DisplayName => typeof(Units).GetMember(((Units) _unitId).ToString())
            .FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? Name;
    }
}
