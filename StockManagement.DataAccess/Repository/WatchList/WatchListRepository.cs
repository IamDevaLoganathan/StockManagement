using Microsoft.EntityFrameworkCore;
using StockManagement.DataAccess.Data;
using StockManagement.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Repository.WatchList
{
    public class WatchListRepository : IWatchListRepository
    {
        public readonly ApplicationDbContext dbContext;
        public WatchListRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<WatchListDomain> Create(WatchListDomain watchListDomain)
        {
            await dbContext.WatchLists.AddAsync(watchListDomain);
            await dbContext.SaveChangesAsync();
            return watchListDomain;
        }

        public async Task<WatchListDomain> Delete(Guid Id)
        {
            var watchList = await dbContext.WatchLists.FirstOrDefaultAsync(x => x.Id == Id);
            if (watchList != null)
            {
                dbContext.WatchLists.Remove(watchList);
                dbContext.SaveChanges();
            }
            return watchList;
        }

        public async Task<List<WatchListDomain>> GetAll()
        {
            var watchList = await dbContext.WatchLists.Include(x => x.StockDomain).ToListAsync();
            return watchList;
        }

        public async Task<WatchListDomain> GetById(Guid Id)
        {
            var watchList = await dbContext.WatchLists.Include(x=>x.StockDomain).FirstOrDefaultAsync(u=>u.Id==Id);
            return watchList;

        }

        public async Task<WatchListDomain> Update(Guid Id, WatchListDomain watchListDomain)
        {
            var watchList = await dbContext.WatchLists.FirstOrDefaultAsync(u=>u.Id== Id);
            if (watchList == null)
            {
                return null;
            }

            watchList.Capital = watchListDomain.Capital;
            watchList.MarketType = watchListDomain.MarketType;
            watchList.EntryType = watchListDomain.EntryType;
            watchList.Reason = watchListDomain.Reason;
            watchList.StockDomain = watchListDomain.StockDomain;

            dbContext.SaveChanges();

            return watchList;
        }

    }
}
