using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using StockManagement.DataAccess.Data;
using StockManagement.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Repository.Stock
{
    public class StockRepository : IStockRepository
    {
        public readonly ApplicationDbContext dbContext;
        public StockRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<StockDomain> Create(StockDomain StockDomain)
        {
           
           await dbContext.Stocks.AddAsync(StockDomain);
           await dbContext.SaveChangesAsync();
           return StockDomain;
        }

        public async Task<StockDomain> Delete(Guid Id)
        {
            var stockDomain = await dbContext.Stocks.FirstOrDefaultAsync(u => u.Id == Id);
            if (stockDomain != null)
            {
                dbContext.Stocks.Remove(stockDomain);
                dbContext.SaveChanges();
            }
           
            return stockDomain;
        }

        public async Task<List<StockDomain>> GetALl()
        {
            return await dbContext.Stocks.ToListAsync();
        }

        public async Task<StockDomain> GetbyID(Guid Id)
        {
            return await dbContext.Stocks.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<StockDomain> Update(Guid Id, StockDomain StockDomain)
        {
            var ExistDomain = await dbContext.Stocks.FirstOrDefaultAsync(u=>u.Id == Id);
            if(ExistDomain == null)
            {
                return null;
            }
            ExistDomain.StockDescription = StockDomain.StockDescription;
            ExistDomain.StockPrice = StockDomain.StockPrice;
            ExistDomain.StockCapital = StockDomain.StockCapital;
            ExistDomain.StockStatus = StockDomain.StockStatus;
            ExistDomain.StockName = StockDomain.StockName;

            await dbContext.SaveChangesAsync();

            return ExistDomain;
        }
    }
}
