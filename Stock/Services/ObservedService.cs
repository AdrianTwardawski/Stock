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
                obj.Market = _dbContext.Market.FirstOrDefault(u => u.Id == obj.MarketId);
                var KursRound = MathF.Round(obj.Market.Price, 2);
                obj.Profit = (KursRound - obj.PurchasePrice) * obj.NumberOfActions;
            }       
            return objList;
        }

        public void Create(ObservedVM model)
        {
            var dbStock = _dbContext.Market.FirstOrDefault(s => s.Id == model.MarketId);
            var observed = new Observed
            {
                MarketId = model.MarketId,
                NumberOfActions = model.NumberOfActions,
                PurchasePrice = model.PurchasePrice,
                Stock = dbStock.Stock,
                Profit = model.NumberOfActions * (model.PurchasePrice - dbStock.Price)
            };

            _dbContext.Observed.Add(observed);
            _dbContext.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetTypeDropDown()
        {
            var TypeDropDown = _dbContext.Market.Select(i => new SelectListItem
            {
                Text = i.Stock,
                Value = i.Id.ToString()
            });
            return TypeDropDown;
            
        }
        
        public void Update(ObservedVM model)
        {
            var dbStock = _dbContext.Observed.FirstOrDefault(s => s.MarketId == model.MarketId);           
            dbStock.NumberOfActions = model.NumberOfActions;
            dbStock.PurchasePrice = model.PurchasePrice;
           
            _dbContext.SaveChanges();
        }

        public Observed GetById(int? id)
        {
            var obj = _dbContext.Observed.Find(id);
            return obj;
        }
    }
}