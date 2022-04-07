using API.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ApplicationDBContext _dbContext;
        public CoffeeShopService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CoffeeShopModel>> List()
        {
            var coffeeShops = await (from shop in _dbContext.CoffeeShops
                                     select new CoffeeShopModel()
                                     {
                                         Id = shop.Id,
                                         Address = shop.Address,
                                         Name = shop.Name,
                                         OpeningHours = shop.OpeningHours
                                     }).ToListAsync();
            return coffeeShops;
        }
    }
}
