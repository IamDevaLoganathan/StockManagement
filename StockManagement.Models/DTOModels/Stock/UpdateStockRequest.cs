using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Models.DTOModels.Stock
{
    public class UpdateStockRequest
    {
        [Required]
        [MaxLength(6, ErrorMessage = "Stock name must have the length of 6 Charactors")]
        public string StockName { get; set; }

        [Required]
        public string StockStatus { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Price should be the range between 0 to 1000")]
        public int StockPrice { get; set; }

        [Required]
        [Range(50000, 100000, ErrorMessage = "Company capital must have the minimum of 50k to 100k")]
        public int StockCapital { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(4)]
        public string StockDescription { get; set; }
    }
}
