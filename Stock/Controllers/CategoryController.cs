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
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {         
            _categoryService = categoryService;
        }

        public IActionResult Index(int pg = 1, string SearchText = "", string sortOrder = "")
        {    
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["SortIconWalor"] = "";
            ViewData["SortIconZmiana"] = "";
            var stocks = _categoryService.AddStocks();

            switch (sortOrder)
            {
                case "name_desc":
                    stocks = stocks.OrderByDescending(s => s.Walor).ToList();
                    ViewData["SortIconWalor"] = "fa fa-arrow-up";
                    break;
                case "Date":
                    stocks = stocks.OrderBy(s => s.Zmiana).ToList();
                    ViewData["SortIconZmiana"] = "fa fa-arrow-down";
                    break;
                case "date_desc":
                    stocks = stocks.OrderByDescending(s => s.Zmiana).ToList();
                    ViewData["SortIconZmiana"] = "fa fa-arrow-up";
                    break;
                default:
                    stocks = stocks.OrderBy(s => s.Walor).ToList();
                    ViewData["SortIconWalor"] = "fa fa-arrow-down";               
                    break;
            }
           
            /*if (SearchText != "" && SearchText != null)*/
            if (!String.IsNullOrEmpty(SearchText))
            {
                string SearchTextUpper = SearchText.ToUpper();
                var searchStocks = stocks.Where(p => p.Walor.Contains(SearchTextUpper)).ToList();
                return View(searchStocks);
            }

            const int pageSize = 20;
            if (pg < 1)
                pg = 1;

            int recsCount = stocks.Count();
            var pager = new Pager(recsCount, pg, pageSize); //SPager SearchPager = new SPager(recsCount, pg, pageSize) { Action = "Index", Controller = "Category", SearchText = SearchText };
            int recSkip = (pg - 1) * pageSize;
            var data = stocks.Skip(recSkip).Take(pager.PageSize).ToList(); //List<Category> retProducts = stocks.Skip(recSkip).Take(pageSize).ToList()
            this.ViewBag.Pager = pager; //ViewBag.SearchPager = SearchPager;

            return View(data); //return View(retProducts);
        }
    }
}