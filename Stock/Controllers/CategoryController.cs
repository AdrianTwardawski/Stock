using Microsoft.AspNetCore.Mvc;
using Stock.Data;
using Stock.Models;
using Stock.Services;
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
        private readonly ICategoryService _categoryService;

        public CategoryController(ApplicationDbContext db, IStockScraper stockScraper, ICategoryService categoryService)
        {
            _db = db;
            _stockScraper = stockScraper;
            _categoryService = categoryService;
        }

        
        
        public IActionResult Index()
        {
           var stocks = _categoryService.GetAllStocks();        
                return View(stocks);                    
        }
    
    }
}