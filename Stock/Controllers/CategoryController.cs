using Microsoft.AspNetCore.Mvc;
using Stock.Data;
using Stock.Models;
using Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Stock.Views.Shared.Components.SearchBar;

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

        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            var stocks = _categoryService.GetAllStocks();

            if (SearchText != "" && SearchText != null)
            {
                string SearchTextUpper = SearchText.ToUpper();
                stocks = _categoryService.GetAllStocks()
               .Where(p => p.Walor.Contains(SearchTextUpper))
               .ToList();
            }

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = stocks.Count();
            var pager = new Pager(recsCount, pg, pageSize); //SPager SearchPager = new SPager(recsCount, pg, pageSize) { Action = "Index", Controller = "Category", SearchText = SearchText };
            int recSkip = (pg - 1) * pageSize;
            var data = stocks.Skip(recSkip).Take(pager.PageSize).ToList(); //List<Category> retProducts = stocks.Skip(recSkip).Take(pageSize).ToList()
            this.ViewBag.Pager = pager; //ViewBag.SearchPager = SearchPager;

            //return View(stocks);
            return View(data); //return View(retProducts);
        }
    }
}