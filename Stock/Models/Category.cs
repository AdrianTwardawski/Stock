using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models
{
    public enum SortOrder { Ascending = 0, Descending = 1}
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Spółka")]
        public string Walor { get; set; }
        public string Kurs { get; set; }
        [DisplayName("Kurs")]
        public float KursFloat { get; set; }
        public float Zmiana { get; set; }


    }
}
