using Stock.Data;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllStocks();
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
        public List<Category> GetAllStocks()
        {
            var stocks = _stockScraper.GetStocks();
            foreach (var itemScraped in stocks)
            {
                var itemInDb = _db.Category.FirstOrDefault(i => i.Walor == itemScraped.Walor);
                itemInDb.Kurs = itemScraped.Kurs;
                itemInDb.Zmiana = itemScraped.Zmiana;
                itemInDb.KursFloat = itemScraped.KursFloat;
                _db.Category.Update(itemInDb);          
            }
            _db.SaveChanges();
            return (List<Category>)stocks;
        }
    }
}
