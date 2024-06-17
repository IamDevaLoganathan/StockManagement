using StockManagement.DTOModels.Stock;
using StockManagement.Models.DomainModels;
using StockManagement.Models.DTOModels.Stock;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.DTOModels.WatchList
{
    public class WatchListDTO
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public int Capital { get; set; }
        public string MarketType { get; set; }
        public string EntryType { get; set; }
        public UpdateStockRequest StockDomain { get; set; }
    }
}
