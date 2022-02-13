using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Utility
{
    public static class Helper
    {
        public const string Admin = "Admin";
        public static string NormalUser = "Normal User";
        public static string PremiumUser = "Premium User";
   
        public static List<SelectListItem> GetRoles()
        {          
                return new List<SelectListItem>
                {                       
                        new SelectListItem { Value = Helper.NormalUser, Text = Helper.NormalUser },
                        new SelectListItem { Value = Helper.PremiumUser, Text = Helper.PremiumUser }
                };           
        }

    }
}