using Microsoft.EntityFrameworkCore;
using Stock.Data;
using Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock
{
    public interface ISeeder
    {
        void Seed();
    }

    public class Seeder : ISeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICategoryService _categoryService;
        public Seeder(ApplicationDbContext dbContext, ICategoryService categoryService)
        {
            _dbContext = dbContext;
            _categoryService = categoryService;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
                 
                if (_dbContext.Category.Any()) return;
                {
                    var stocks = _categoryService.AddStocks();

                    foreach (var stock in stocks)
                    {
                        _dbContext.Category.Add(stock);
                    }
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}