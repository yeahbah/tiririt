using IdentityServer4;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Tiririt.App.Stock;
using Tiririt.App.Stock.Queries;
using Tiririt.Web.Common;

namespace Tiririt.Web.Controllers
{
    [AllowAnonymous]
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class StockController : TiriritControllerBase
    {
        private readonly IMediator mediator;

        public StockController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(RouteConsts.Stock.GetStock)]    
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetStock(string symbol, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetStockQuery(symbol), cancellationToken);
            return OkOrNotFound(result);
        }        
    }
}