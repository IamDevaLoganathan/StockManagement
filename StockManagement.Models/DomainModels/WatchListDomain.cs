using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models.DomainModels
{
    public class WatchListDomain
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public int Capital { get; set; }

        [Required]
        public string MarketType { get; set; }

        [Required]
        public string EntryType { get; set; }

        public Guid StockDomainId { get; set; }

        // Navigation
        public StockDomain StockDomain { get; set; }


    }
}
