using System;
using System.ComponentModel.DataAnnotations;

namespace HomeStats.Models
{
    /// <summary>
    /// Счётчик воды
    /// </summary>
    public class WaterCounter
    {
        /// <summary>
        /// Id Счётчика
        /// </summary>
        [Key]
        public int IdWaterCounter { get; set; }

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
