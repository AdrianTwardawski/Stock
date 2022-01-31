using HtmlAgilityPack;
using Stock.Data;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock
{
    public interface IStockScraper
    {
        IEnumerable<Category> GetStocks();
    }

    public class StockScraper : IStockScraper
    {

        private const string BaseUrl = "https://www.bankier.pl/gielda/notowania/akcje";

        public IEnumerable<Category> GetStocks()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);
            var tableRows = document.QuerySelectorAll("table tr").Skip(1).Skip(11);

            var stocks = new List<Category>();

            foreach (var tableRow in tableRows)
            {
                var tds = tableRow.QuerySelectorAll("td");

                var walor = tds[0].QuerySelector("a").InnerText;
                var kurs = tds[1].InnerText;
                var zmiana = tds[2].InnerText;
                float kursFloat = float.Parse(kurs.Replace(",", ".").Replace("&nbsp;", ""));
                float zmianaFloat = MathF.Round((kursFloat*100)/(kursFloat-(float.Parse(zmiana.Replace(",", ".").Replace("&nbsp;", ""))))-100,2);              
                var stock = new Category
                {
                    Walor = walor,
                    Kurs = kurs,
                    KursFloat = kursFloat,
                    Zmiana = zmianaFloat
                };

                stocks.Add(stock);
            }
            return stocks;
        }
    }
}