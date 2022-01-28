using Stock.Data;
using Stock.Models;
using Stock.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Services
{
    public interface IObservedService
    {
        IEnumerable<Observed> GetUserStocks();
        void Create(ObservedVM model);
        void Update(ObservedVM model);
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
                _dbContext.Observed.Update(obj);
            }
            _dbContext.SaveChanges();
            return objList;
        }

        public void Create(ObservedVM model)
        {
            var dbStock = _dbContext.Category.FirstOrDefault(s => s.Id == model.CategoryId);
            var observed = new Observed
            {
                CategoryId = model.CategoryId,
                LiczbaAkcji = model.LiczbaAkcji,
                CenaZakupu = model.CenaZakupu,
                Walor = dbStock.Walor,
                Zysk = model.LiczbaAkcji * (model.CenaZakupu - dbStock.KursFloat)
            };

            _dbContext.Observed.Add(observed);
            _dbContext.SaveChanges();
        }
        
        public void Update(ObservedVM model)
        {
            var dbStock = _dbContext.Observed.FirstOrDefault(s => s.CategoryId == model.CategoryId);
            model.Walor = dbStock.Walor;
            dbStock.LiczbaAkcji = model.LiczbaAkcji;
            dbStock.CenaZakupu = model.CenaZakupu;
           
            _dbContext.SaveChanges();
        }
    }
}