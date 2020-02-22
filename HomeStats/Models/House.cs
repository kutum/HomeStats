using System;
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

        /// <summary>
        /// Серийный номер
        /// </summary>
        [Required, Display(Name = "Серийный номер")]
        public string Serial { get; set; }

        /// <summary>
        /// Показания счётчика
        /// </summary>
        [Range(0, Int32.MaxValue), Display(Name = "Показания счётчика")]
        public int Reading { get; set; }
    }
}
