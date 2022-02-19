using Microsoft.EntityFrameworkCore;
using Stock.Data;
using Stock.Services;
using System.Linq;

namespace Stock
{
    public interface ISeeder
    {
        void Seed();
    }

    public class Seeder : ISeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMarketService _marketService;
        public Seeder(ApplicationDbContext dbContext, IMarketService marketService)
        {
            _dbContext = dbContext;
            _marketService = marketService;
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
                 
                if (_dbContext.Market.Any()) return;
                {
                    var stocks = _marketService.AddStocks();

                    foreach (var stock in stocks)
                    {
                        _dbContext.Market.Add(stock);
                    }
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}