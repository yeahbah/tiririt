using IdentityServer4;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Tiririt.App.Models;
using Tiririt.App.Service;
using Tiririt.App.WatchList.Commands;
using Tiririt.App.WatchList.Queries;
using Tiririt.Core.Collection;
using Tiririt.Web.Common;

namespace Tiririt.Web.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class WatchListController : TiriritControllerBase
    {        
        private readonly IMediator mediator;

        public WatchListController(IMediator mediator)
        {            
            this.mediator = mediator;
        }


        /// <summary>
        /// Returns the default watch list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<PagingResultEnvelope<StockViewModel>>> GetDefaultWatchList([FromQuery] PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetDefaultWatchListQuery { PagingParam = pagingParam });
            return Ok(result);
        }

        //PUT: WatchList/id
        [HttpPut(RouteConsts.WatchList.Stocks)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<WatchListViewModel>> PutStock([FromBody]AddStocksToWatchListCommand addStocksToWatchListCommand, CancellationToken cancellationToken) //([FromRoute]int id, [FromBody]IEnumerable<string> stocks)
        {
            var result = await this.mediator.Send(addStocksToWatchListCommand, cancellationToken);
            return Ok(result);
            //var result = await watchListService
            //    .AddStocks(id, stocks.Distinct());
            //return Ok(result.ToViewModel());
        }

        [HttpPut(RouteConsts.WatchList.Rename)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<WatchListViewModel>> RenameWatchList([FromBody]RenameWatchListCommand renameWatchListCommand, CancellationToken cancellationToken) //(int id, [FromBody]string newName) 
        {
            var result = await this.mediator.Send(renameWatchListCommand, cancellationToken);
            return Ok(result);
            //var result = await watchListService.RenameWatchList(id, newName);
            //return Ok(result.ToViewModel());
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<WatchListViewModel>> NewWatchList([FromBody]NewWatchListCommand newWatchListCommand, CancellationToken cancellationToken) //([FromBody] NewWatchListViewModel watchListModel)
        {
            if (newWatchListCommand == null) return new StatusCodeResult(StatusCodes.Status204NoContent);
            var result = await this.mediator.Send(newWatchListCommand, cancellationToken);
            return Ok(result);
            //var result = await watchListService
            //    .NewWatchList(new Domain.Models.NewWatchListModel
            //    {
            //        Name = watchListModel.Name,
            //        Stocks = watchListModel.Stocks
            //            .Distinct()
            //            .Select(stock => stock.ToUpper())
            //    });
            //return Ok(result.ToViewModel());
        }

        [HttpDelete(RouteConsts.WatchList.DeleteWatchList)]
        public async Task<IActionResult> DeleteWatchList(DeleteWatchListCommand deleteWatchListCommand, CancellationToken cancellationToken)
        {
            //await watchListService.DeleteWatchList(id);
            await this.mediator.Send(deleteWatchListCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [Route(RouteConsts.WatchList.DeleteStock)]
        public async Task<ActionResult<WatchListViewModel>> DeleteStock([FromBody]DeleteStockFromWatchListCommand deleteStockFromWatchListCommand, CancellationToken cancellationToken)//([FromRoute]int id, string symbol)
        {
            var result = await this.mediator.Send(deleteStockFromWatchListCommand, cancellationToken);
            return Ok(result);
            //var result = await this.watchListService
            //    .DeleteStocks(id, symbol);
            //return Ok(result.ToViewModel());
        }
    }
}