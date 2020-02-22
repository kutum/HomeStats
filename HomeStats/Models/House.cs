using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeStats.Models
{
    /// <summary>
    /// Дом
    /// </summary>
    public class House
    {
        /// <summary>
        /// Id Дома
        /// </summary>
        [Key]
        public int IdHouse { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        [Required, Display(Name = "Улица"), StringLength(100,MinimumLength = 3)]
        public string StreetName { get; set; }
        /// <summary>
        /// Дом
        /// </summary>
        [Required, Display(Name = "Номер дома"), StringLength(10, MinimumLength = 1)]
        public string HouseNumber { get; set; }

        public ICollection<WaterCounter> WaterCounters { get; set; }

        public House()
        {
            WaterCounters = new List<WaterCounter>();
        }
    }
}
