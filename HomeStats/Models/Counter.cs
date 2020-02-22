using System;
using System.ComponentModel.DataAnnotations;

namespace HomeStats.Models
{
    public class Counter
    {
        [Key]
        public int IdCounter { get; set; }

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

        public int IdHouse { get; set; }
        public House House { get; set; }
    }
}
