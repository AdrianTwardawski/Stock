using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Walor { get; set; }
        public string Kurs { get; set; }
        public string Zmiana { get; set; }


    }
}
