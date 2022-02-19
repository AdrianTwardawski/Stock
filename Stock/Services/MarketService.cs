using HtmlAgilityPack;
using Stock.Data;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stock.Services
{
    public interface IMarketService
    {
        IEnumerable<Market> AddStocks();
        IEnumerable<Market> GetStocks();
    }

    public class MarketService : IMarketService
    {
        private readonly ApplicationDbContext _db;
        private const string BaseUrl = "https://www.bankier.pl/gielda/notowania/akcje";

        public MarketService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Market> AddStocks()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);
            var tableRows = document.QuerySelectorAll("table tr").Skip(1).Skip(11);
            
            var markets = new List<Market>();

            foreach (var tableRow in tableRows)
            {
                var tds = tableRow.QuerySelectorAll("td");
                var stock = tds[0].QuerySelector("a").InnerText;
                var price = float.Parse(tds[1].InnerText.Replace(",", ".").Replace("&nbsp;", ""));
                var change = MathF.Round((price * 100) / (price - (float.Parse(tds[2].InnerText.Replace(",", ".").Replace("&nbsp;", "")))) - 100, 2);
                var time = tds[9].InnerText;
              
                var itemInDb = _db.Market.FirstOrDefault(i => i.Stock == stock);


                if (itemInDb == null)
                {
                    var market = new Market
                    {
                        Stock = stock,
                        Price = price,
                        Change = change,
                        Time = time
                    };
                    markets.Add(market);
                }
                else               
                {
                    itemInDb.Stock = stock;
                    itemInDb.Change = change;
                    itemInDb.Price = price;
                    itemInDb.Time = time;                         
                }
            }
            _db.SaveChanges();           
            return markets;
        }

        public IEnumerable<Market> GetStocks()
        {
            AddStocks();
            var stocks = _db.Market.ToList();
            return stocks;
        }
    }
}