using StockManagement.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Repository.WatchList
{
    public interface IWatchListRepository
    {
        Task<List<WatchListDomain>> GetAll();
        Task<WatchListDomain> GetById(Guid Id);
        Task<WatchListDomain> Delete(Guid Id);
        Task<WatchListDomain> Update(Guid Id, WatchListDomain watchListDomain);
        Task<WatchListDomain> Create(WatchListDomain watchListDomain);

    }
}
