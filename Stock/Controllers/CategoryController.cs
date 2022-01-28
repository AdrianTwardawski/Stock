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



        public IActionResult Index(int pg = 1)
        {
            var stocks = _categoryService.GetAllStocks();

            const int pageSize = 30;
            if (pg < 1)
                pg = 1;

            int recsCount = stocks.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = stocks.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(stocks);
            return View(data);
        }

    }
}