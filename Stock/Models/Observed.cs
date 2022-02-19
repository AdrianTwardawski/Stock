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
        public string Stock { get; set; }
        public float PurchasePrice { get; set; }
        [DisplayName("Number of actions")]
        public int NumberOfActions { get; set; }
        public float Profit { get; set; }
        public int MarketId { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual Market Market { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}