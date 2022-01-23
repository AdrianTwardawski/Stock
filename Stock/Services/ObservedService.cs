using Stock.Data;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Services
{
    public interface IObservedService
    {
        IEnumerable<Observed> GetUserStocks();
    }

    public class ObservedService : IObservedService
    {
        private readonly ApplicationDbContext _dbContext;
        public ObservedService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Observed> GetUserStocks()
        {
            var objList = _dbContext.Observed;
            foreach (var obj in objList)
            {
                obj.Category = _dbContext.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
                var KursConv = float.Parse(obj.Category.Kurs.Replace(",", "."));
                var KursRound = MathF.Round(KursConv, 2);
                obj.Zysk = (KursRound - obj.CenaZakupu) * obj.LiczbaAkcji;
            }
            return objList;
        }
    }
}
