using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Observed
    {
        public int Id { get; set; }
        public string Walor { get; set; }
        public float CenaZakupu { get; set; }
        public int LiczbaAkcji { get; set; }
        public float Zysk { get; set; }
        public int CategoryId { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}