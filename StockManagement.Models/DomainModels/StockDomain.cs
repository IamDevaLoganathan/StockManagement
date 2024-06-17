using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models.DomainModels
{
    public class StockDomain
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string StockName { get; set; }

        [Required]
        public string StockStatus { get; set; }

        [Required]
        public int StockPrice { get; set; }

        [Required]
        public int StockCapital { get; set; }

        [Required]
        public string StockDescription { get; set; }
    }
}
