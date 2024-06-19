using Microsoft.AspNetCore.Mvc;
using StockManagement.UI.Models.DTO;
using System.Collections.Generic;
using System.Net.Http;

namespace StockManagement.UI.Controllers
{
    public class StockController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StockController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> StockGetAll()
        {
            List<StockDTO> stocks = new List<StockDTO>();

            var client = httpClientFactory.CreateClient();

            HttpResponseMessage Response = await client.GetAsync("https://localhost:7291/api/v1/stock");

            Response.EnsureSuccessStatusCode();

            stocks.AddRange(await Response.Content.ReadFromJsonAsync<IEnumerable<StockDTO>>());

            return View(stocks);
        }
    }
}
