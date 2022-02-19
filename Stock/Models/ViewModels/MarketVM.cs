using System.ComponentModel;

namespace Stock.Models.ViewModels
{
    public class MarketVM
    {
        public int Id { get; set; }
        public string Stock { get; set; }
        public float Price { get; set; }
        public float Change { get; set; }
    }
}
