using System.ComponentModel;

namespace Stock.Models.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Walor { get; set; }
        [DisplayName("Kurs")]
        public float KursFloat { get; set; }
        public float Zmiana { get; set; }
    }
}
