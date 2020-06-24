using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Web.Common;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers
{
    [AllowAnonymous]
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
        public async Task<IActionResult> GetStock(string symbol)
        {
            var result = await stockService
                .GetStock(symbol);
            return OkOrNotFound(result.ToViewModel());
        }        
    }
}