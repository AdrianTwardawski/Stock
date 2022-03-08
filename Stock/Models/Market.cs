using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Models
{

    public class Market
    {
        [Key]
        public int Id { get; set; }
        public string Stock { get; set; }
        public float Price { get; set; }
        [DisplayName("Price [PLN]")]
        public float Change { get; set; }
        public string TradesValue { get; set; }
        public string Time { get; set; }


    }
}
