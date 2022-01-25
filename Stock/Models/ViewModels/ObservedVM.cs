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
        
        public string Walor { get; set; }
        [DisplayName("Cena zakupu")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public float CenaZakupu { get; set; }
        [DisplayName("Liczba akcji")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int LiczbaAkcji { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }

    }
}