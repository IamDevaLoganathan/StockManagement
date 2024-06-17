using StockManagement.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Repository.Stock
{
    public interface IStockRepository
    {
        Task <List<StockDomain>> GetALl();
        Task <StockDomain> GetbyID(Guid Id);
        Task<StockDomain> Delete(Guid Id);
        Task <StockDomain> Update(Guid Id, StockDomain StockDomain);
        Task <StockDomain> Create(StockDomain StockDomain);

    }
}
