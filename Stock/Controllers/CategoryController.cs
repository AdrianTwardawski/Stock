using Microsoft.AspNetCore.Mvc;
using Stock.Data;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IStockScraper _stockScraper;

        public CategoryController(ApplicationDbContext db, IStockScraper stockScraper)
        {
            _db = db;
            _stockScraper = stockScraper;
        }

        
        
        public IActionResult Index()
        {
            var stocks = _stockScraper.GetStocks();           
            foreach (var stock in stocks)
            {               
                _db.Category.Update(stock);
                _db.SaveChanges();
            }

            return View(stocks);
        }

        //POST - Update
       [HttpGet]      
        public IActionResult Update(Category category)
        {                          
            var stocks = _stockScraper.GetStocks();
            foreach (var stock in stocks)
            {
               _db.Category.Update(stock);
               _db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
    }
}