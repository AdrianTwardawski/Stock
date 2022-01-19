using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models.ViewModels
{
    public class CategoryVM
    {
     
        public string Walor { get; set; }
        public string Kurs { get; set; }
        public float KursFloat { get; set; }
        public float Zmiana { get; set; }
    }  
}
