using HtmlAgilityPack;
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
        IEnumerable<Category> AddStocks();
        IEnumerable<Category> GetStocks();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        private const string BaseUrl = "https://www.bankier.pl/gielda/notowania/akcje";

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Category> AddStocks()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);
            var tableRows = document.QuerySelectorAll("table tr").Skip(1).Skip(11);

            var stocks = new List<Category>();

            foreach (var tableRow in tableRows)
            {
                var tds = tableRow.QuerySelectorAll("td");
                var walor = tds[0].QuerySelector("a").InnerText;
                var kurs = float.Parse(tds[1].InnerText.Replace(",", ".").Replace("&nbsp;", ""));
                var zmiana = MathF.Round((kurs * 100) / (kurs - (float.Parse(tds[2].InnerText.Replace(",", ".").Replace("&nbsp;", "")))) - 100, 2);
                var czas = tds[9].InnerText;
              
                var itemInDb = _db.Category.FirstOrDefault(i => i.Walor == walor);

                if (itemInDb == null)
                {
                    var stock = new Category
                    {
                        Walor = walor,
                        Kurs = kurs,
                        Zmiana = zmiana,
                        Czas = czas
                    };
                    stocks.Add(stock);
                }
                else               
                {
                    itemInDb.Zmiana = zmiana;
                    itemInDb.Kurs = kurs;
                    itemInDb.Czas = czas;
                    _db.Category.Update(itemInDb);                   
                }
            }
            _db.SaveChanges();            
            return stocks;
        }

        public IEnumerable<Category> GetStocks()
        {
            AddStocks();
            var stocks = _db.Category.ToList();
            return stocks;
        }
    }
}