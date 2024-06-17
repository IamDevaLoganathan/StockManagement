using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Models.DTOModels.WatchList
{
    public class AddWatchListRequest
    {
        [Required]
        [MaxLength(10, ErrorMessage ="Your response should be lessthen 10 Letters")]
        public string Reason { get; set; }

        [Required]
        [Range(1000, 100000, ErrorMessage ="Your Capital shouild be between 1000 - 100000")]
        public int Capital { get; set; }

        [Required]
        [MaxLength(3, ErrorMessage ="Market type should be either NSE or BSE")]
        public string MarketType { get; set; }

        [Required]
        [MaxLength (4, ErrorMessage = "Entry type should be either Call or Put")]
        public string EntryType { get; set; }
        public Guid StockDomainId { get; set; }
    }
}
