using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.DataAccess.Data;
using StockManagement.DataAccess.Repository.Stock;
using StockManagement.DTOModels.Stock;
using StockManagement.Models.DomainModels;
using StockManagement.Models.DTOModels.Stock;
using System.ComponentModel;

namespace StockManagement.Controllers.v2
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]


    public class StockController : ControllerBase
    {
        // Dependancy Injection
        public readonly ApplicationDbContext dbContext;
        public readonly IStockRepository IStock;
        public readonly IMapper mapper;
        private readonly ILogger<StockController> logger;
        public StockController(IMapper mapper, ApplicationDbContext dbContext, IStockRepository IStock, ILogger<StockController> logger)
        {
            this.dbContext = dbContext;
            this.IStock = IStock;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpGet]
        [Route("RetriveAll")]
        public async Task<IActionResult> RetriveAll()
        {
            // Retrive Data with the help of Repositoru //
            var stockDomain = await IStock.GetALl();

            logger.LogInformation("Records Fetched Succesfully");

            // Mapping (Domain to DTO) // with the help of Automapper //
            var DTO = mapper.Map<List<StockDTO>>(stockDomain);

            //Return DTO to User //
            return Ok(DTO);

        }




    }
}
