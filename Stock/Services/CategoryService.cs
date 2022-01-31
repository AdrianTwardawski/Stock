using Stock.Data;
using Stock.Models;
using Stock.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllStocks();
        //IEnumerable<CategoryVM> StocksDtos();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IStockScraper _stockScraper;
        public CategoryService(ApplicationDbContext db, IStockScraper stockScraper)
        {
            _db = db;
            _stockScraper = stockScraper;
        }
        public IEnumerable<Category> GetAllStocks()
        {
            var stocks = _stockScraper.GetStocks();
            foreach (var itemScraped in stocks)
            {
                var itemInDb = _db.Category.FirstOrDefault(i => i.Walor == itemScraped.Walor);
                if (itemInDb == null)
                {
                    var stock = new Category
                    {
                        Walor = itemScraped.Walor,
                        Kurs = itemScraped.Kurs,
                        KursFloat = itemScraped.KursFloat,
                        Zmiana = itemScraped.Zmiana
                    };
                    _db.Category.Add(stock);                 
                }
                else
                {
                    itemInDb.Kurs = itemScraped.Kurs;
                    itemInDb.Zmiana = itemScraped.Zmiana;
                    itemInDb.KursFloat = itemScraped.KursFloat;
                    _db.Category.Update(itemInDb);
                }
            }           
            _db.SaveChanges();

            return stocks;
        }

        //public IEnumerable<CategoryVM> StocksDtos()
        //{
        //    var stocks = GetAllStocks();
        //    var stocksDtos = stocks.Select(s => new CategoryVM()
        //    {
        //        Id = s.Id,
        //        Walor = s.Walor,
        //        KursFloat = s.KursFloat,
        //        Zmiana = s.Zmiana
        //    });
        //    return stocksDtos;
        //}
    }
}