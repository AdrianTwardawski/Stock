using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models.ViewModels
{
    public class ObservedVM
    {
        
        public string Stock { get; set; }
        [DisplayName("Purchase price")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public float PurchasePrice { get; set; }
        [DisplayName("Number of actions")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int NumberOfActions { get; set; }
        [DisplayName("Market")]
        public int MarketId { get; set; }
        [ForeignKey("MarketId")]
        public virtual Market Market { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }

    }
}