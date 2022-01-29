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

        public IActionResult Index(int pg = 1, string SearchText = "", string sortExpression="")
        {
            ViewData["SortParamWalor"] = "walor";
            ViewData["SortParamZmiana"] = "zmiana";

            ViewData["SortIconWalor"] = "";
            ViewData["SortIconZmiana"] = "";

            SortOrder sortOrder;
            string sortProperty;

            switch (sortExpression.ToLower())
            {
                case "walor_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "walor";
                    ViewData["SortParamWalor"] = "walor";
                    ViewData["SortIconWalor"] = "fa fa-arrow-up";
                    break;

                case "zmiana":
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "zmiana";
                    ViewData["SortParamZmiana"] = "zmiana_desc";
                    ViewData["SortIconZmiana"] = "fa fa-arrow-down";
                    break;

                case "zmiana_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "zmiana";
                    ViewData["SortParamZmiana"] = "zmiana";
                    ViewData["SortIconZmiana"] = "fa fa-arrow-up";
                    break;

                default:                   
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "walor";
                    ViewData["SortIconWalor"] = "fa fa-arrow-down";
                    ViewData["SortParamWalor"] = "walor_desc";
                    break;

            }


            var stocks = _categoryService.GetAllStocks(sortProperty, sortOrder);

            if (SearchText != "" && SearchText != null)
            {
                string SearchTextUpper = SearchText.ToUpper();
                stocks = _categoryService.GetAllStocks(sortProperty, sortOrder)
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