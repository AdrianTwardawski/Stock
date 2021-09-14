using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Observed
    {
        [Key]
        public int Id { get; set; }
        public string Walor { get; set; }
        public float CenaZakupu { get; set; }
        public int LiczbaAkcji { get; set; }
        
    }
}
