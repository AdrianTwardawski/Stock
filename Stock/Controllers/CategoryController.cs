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

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            var stockScraper = new StockScraper();
            var stocks = stockScraper.GetStocks();
            foreach (var stock in stocks)
            {            
                _db.Category.Add(stock);
                _db.SaveChanges();
            }
            
            return View(stocks);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }
    }
}
