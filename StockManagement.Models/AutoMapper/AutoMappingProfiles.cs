using AutoMapper;
using StockManagement.DTOModels.Stock;
using StockManagement.DTOModels.WatchList;
using StockManagement.Models.DomainModels;
using StockManagement.Models.DTOModels.Stock;
using StockManagement.Models.DTOModels.WatchList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Models.AutoMapper
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<StockDomain,StockDTO>().ReverseMap();
            CreateMap<StockDomain,AddStockRequest>().ReverseMap();
            CreateMap<StockDomain,UpdateStockRequest>().ReverseMap();

            CreateMap<WatchListDomain,WatchListDTO>().ReverseMap();
            CreateMap<WatchListDomain,AddWatchListRequest>().ReverseMap();
            CreateMap<WatchListDomain, UpdateWatchListRequest>().ReverseMap();

        }
    }
}
