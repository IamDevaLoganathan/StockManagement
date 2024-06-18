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

namespace StockManagement.Controllers
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]


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
        [Authorize(Roles = "Reader")]
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



        [HttpGet]
        [Route("RetriveById")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> Retrive(Guid Id)
        {
            // Retrive Data with the help of Repositoru //
            var StockDomain = await IStock.GetbyID(Id);

            if (StockDomain == null)
            {
                return BadRequest();
            }

            // Mapping (Domain to DTO) // with the help of Automapper //
            var DTO = mapper.Map<StockDTO>(StockDomain);

            // Return DTO to User //
            return Ok(DTO);
        }



        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create(AddStockRequest addStockRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else 
            {
                // Mapping (DTO to Domain) // with the help of Automapper //
                var StockDomain = mapper.Map<StockDomain>(addStockRequest);

                // Create Data with the help of Repository //
                var newStock = await IStock.Create(StockDomain);

                // Mapping (Domain to DTO) // with the help of Automapper //
                var DTO = mapper.Map<StockDTO>(newStock);

                // Return DTO to User //
                return Ok(DTO);
            }
         
        }
       



        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete(Guid Id)
        {

            // Delete Data with the help of Repository //
            var stockDomain = await IStock.Delete(Id);
            if (stockDomain == null)
            {
                return NotFound();
            }

            // Mapping (Domain to DTO) // with the help of Automapper //
            var DTO = mapper.Map<StockDTO>(stockDomain);

            // Return DTO to User //
            return Ok(DTO);
        }

        [HttpPut]
        [Route("Update")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Edit(Guid Id, UpdateStockRequest updateStockRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                // Mapping (DTO to Domain) // with the help of Auto Mapper
                var stockDomain = mapper.Map<StockDomain>(updateStockRequest);

                // Update Data with the help of Repository //
                var Updateddomain = await IStock.Update(Id, stockDomain);

                // Mapping (Domain to DTO) // with the help of Automapper //
                var DTO = mapper.Map<UpdateStockRequest>(Updateddomain);

                // Return DTO to User //
                return Ok(DTO);
            }
      
        }

    }
}
