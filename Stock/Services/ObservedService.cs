using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        IEnumerable<SelectListItem> GetTypeDropDown();
        Observed GetById(int? id);
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
            var objList = _dbContext.Observed.ToList();
            foreach (var obj in objList)
            {
                obj.Category = _dbContext.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
                var KursConv = float.Parse(obj.Category.Kurs.Replace(",", "."));
                var KursRound = MathF.Round(KursConv, 2);
                obj.Zysk = (KursRound - obj.CenaZakupu) * obj.LiczbaAkcji;
            }       
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

        public IEnumerable<SelectListItem> GetTypeDropDown()
        {
            var TypeDropDown = _dbContext.Category.Select(i => new SelectListItem
            {
                Text = i.Walor,
                Value = i.Id.ToString()
            });
            return TypeDropDown;
            
        }
        
        public void Update(ObservedVM model)
        {
            var dbStock = _dbContext.Observed.FirstOrDefault(s => s.CategoryId == model.CategoryId);
            model.Walor = dbStock.Walor;
            dbStock.LiczbaAkcji = model.LiczbaAkcji;
            dbStock.CenaZakupu = model.CenaZakupu;
           
            _dbContext.SaveChanges();
        }

        public Observed GetById(int? id)
        {
            var obj = _dbContext.Observed.Find(id);
            return obj;
        }
    }
}