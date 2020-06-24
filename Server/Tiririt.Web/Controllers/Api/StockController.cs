using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Core.Identity;
using Tiririt.Web.Common;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers
{
    [AllowAnonymous]
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class StockController : TiriritControllerBase
    {
        private readonly IStockService stockService;
        private readonly IStockSectorService stockSectorService;
        private readonly IStockQuoteService stockQuoteService;
        private readonly IWebHostEnvironment environment;
        private readonly ICurrentPrincipal currentPrincipal;
        private readonly IWatchListService watchListService;

        public StockController(
            IStockService stockService, 
            IStockSectorService stockSectorService,
            IStockQuoteService stockQuoteService,
            IWebHostEnvironment environment,
            ICurrentPrincipal currentPrincipal,
            IWatchListService watchListService)
        {
            this.stockService = stockService;
            this.stockSectorService = stockSectorService;
            this.stockQuoteService = stockQuoteService;
            this.environment = environment;
            this.currentPrincipal = currentPrincipal;
            this.watchListService = watchListService;
        }

        [HttpGet(RouteConsts.Stock.GetStock)]    
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetStock(string symbol)
        {
            var stock = await stockService
                .GetStock(symbol);

            var userId = this.currentPrincipal.GetUserId();
            var result = stock.ToViewModel();
            if (userId != null) 
            {
                result.IsWatchedByUser = await this.watchListService.IsWatchedByUser(symbol, userId.Value);
            }
            return OkOrNotFound(result);
        }        
    }
}