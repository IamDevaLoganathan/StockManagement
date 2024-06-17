using System.ComponentModel.DataAnnotations;

namespace StockManagement.DTOModels.Stock
{
    public class StockDTO
    {
        public Guid Id { get; set; }
        public string StockName { get; set; }
        public string StockStatus { get; set; }
        public int StockPrice { get; set; }
        public int StockCapital { get; set; }
        public string StockDescription { get; set; }
    }
}
    