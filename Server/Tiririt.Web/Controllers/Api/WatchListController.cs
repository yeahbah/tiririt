using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Web.Common;
using Tiririt.Web.Models;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class WatchListController : TiriritControllerBase
    {
        private readonly IWatchListService watchListService;

        public WatchListController(IWatchListService watchListService)
        {
            this.watchListService = watchListService;
        }


        /// <summary>
        /// Returns the default watch list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<WatchListViewModel>> Get()
        {
            var result = await watchListService
                .GetWatchList();
            return Ok(result.FirstOrDefault()?.ToViewModel());
        }

        //PUT: WatchList/id
        [HttpPut(RouteConsts.WatchList.Stocks)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<WatchListViewModel>> PutStock([FromRoute]int id, [FromBody]IEnumerable<string> stocks)
        {
            var result = await watchListService
                .AddStocks(id, stocks.Distinct());
            return Ok(result.ToViewModel());
        }
        
        [HttpPut(RouteConsts.WatchList.Rename)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<WatchListViewModel>> RenameWatchList(int id, [FromBody]string newName) 
        {
            var result = await watchListService.RenameWatchList(id, newName);
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<WatchListViewModel>> NewWatchList([FromBody] NewWatchListViewModel watchListModel)
        {
            if (watchListModel == null) return new StatusCodeResult(StatusCodes.Status204NoContent);
            var result = await watchListService
                .NewWatchList(new Domain.Models.NewWatchListModel
                {
                    Name = watchListModel.Name,
                    Stocks = watchListModel.Stocks
                        .Distinct()
                        .Select(stock => stock.ToUpper())
                });
            return Ok(result.ToViewModel());
        }

        [HttpDelete(RouteConsts.WatchList.DeleteWatchList)]
        public async Task<IActionResult> DeleteWatchList(int id)
        {
            await watchListService.DeleteWatchList(id);
            return Ok();
        }

        [HttpDelete]
        [Route(RouteConsts.WatchList.DeleteStock)]
        public async Task<ActionResult<WatchListViewModel>> DeleteStock([FromRoute]int id, string symbol)
        {
            var result = await this.watchListService
                .DeleteStocks(id, symbol);
            return Ok(result.ToViewModel());
        }
    }
}