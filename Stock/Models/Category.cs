using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Walor { get; set; }
        public float Kurs { get; set; }
        [DisplayName("Kurs [PLN]")]
        public float Zmiana { get; set; }
        public string Czas { get; set; }


    }
}
