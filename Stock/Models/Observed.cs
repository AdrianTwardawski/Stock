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
        [Key]
        public int Id { get; set; }
        public string Walor { get; set; }
        public float CenaZakupu { get; set; }
        public int LiczbaAkcji { get; set; }
        public float Zysk { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}
