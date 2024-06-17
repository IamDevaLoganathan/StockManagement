using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagement.DataAccess.Data;
using StockManagement.DataAccess.Repository.WatchList;
using StockManagement.DTOModels.WatchList;
using StockManagement.Models.DomainModels;
using StockManagement.Models.DTOModels.WatchList;

namespace StockManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        public readonly ApplicationDbContext dbcontext;
        public readonly IMapper mapper;
        public readonly IWatchListRepository IWatchList;

        public WatchListController(IMapper mapper, ApplicationDbContext dbContext, IWatchListRepository IWatchList)
        {
            this.dbcontext = dbContext;
            this.mapper = mapper;
            this.IWatchList = IWatchList;
        }


        [HttpGet]
        [Route("RetriveAll")]
        public async Task<IActionResult> RetriveAll()
        {
            // Getting Data with the help of Repository //
            var watchLists = await IWatchList.GetAll();

            // Mapping (Domain to DTO) // Using Auto Mapper //
            var DTO = mapper.Map<List<WatchListDTO>>(watchLists);

            //Return the data to User
            return Ok(DTO);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddWatchListRequest addWatchListRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                // Mapping (DTO to Domain) // using Auto Mapper //
                var watchListDomain = mapper.Map<WatchListDomain>(addWatchListRequest);

                // Create Data with the help of Repository //
                var watchList = await IWatchList.Create(watchListDomain);

                // Mapping (Domain to DTO) // using Auto Mapper //
                var DTO = mapper.Map<AddWatchListRequest>(watchList);

                // Return to User //
                return Ok(DTO);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            // Retrive data using Repository //
            var watchList = await IWatchList.GetById(Id);

            // Mapping (Domain to DTO) // Using Auto Mapper
            var DTO = mapper.Map<WatchListDTO>(watchList);

            //retur to user //
            return Ok(DTO);
        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(Guid Id, UpdateWatchListRequest updateWatchListRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                // Mapping (DTO to Domain)
                var watchList = mapper.Map<WatchListDomain>(updateWatchListRequest);

                // Update the data usinf Repository //
                var watchListDomain = await IWatchList.Update(Id, watchList);

                // Mapping (Domain to DTO)// Using Mapper //
                var DTO = mapper.Map<UpdateWatchListRequest>(watchListDomain);

                // Return to User //
                return Ok(DTO);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            // Delete Data using Repository //
            var DelWatchList = await IWatchList.Delete(Id);

            // Mapping (Domain to DTO) // Using Mapper
            var DTO = mapper.Map<WatchListDTO>(DelWatchList);

            return Ok(DTO);
        }
    }
}
