using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Service;
using Tiririt.Web.Common;

namespace Tiririt.Web.Controllers
{
    public class StockController : TiriritControllerBase
    {
        private readonly IStockService stockService;
        private readonly IStockSectorService stockSectorService;
        private readonly IStockQuoteService stockQuoteService;
        private readonly IWebHostEnvironment environment;

        public StockController(
            IStockService stockService, 
            IStockSectorService stockSectorService,
            IStockQuoteService stockQuoteService,
            IWebHostEnvironment environment)
        {
            this.stockService = stockService;
            this.stockSectorService = stockSectorService;
            this.stockQuoteService = stockQuoteService;
            this.environment = environment;
        }

        [HttpGet(RouteConsts.Stock.GetStock)]    
        [ProducesResponseType(200)]
        public IActionResult GetStock(string symbol)
        {
            var result = stockService.GetStock(symbol);
            return OkOrNotFound(result);
        }        
    }
}