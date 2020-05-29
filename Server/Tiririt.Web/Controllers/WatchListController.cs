using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Service;
using Tiririt.Web.Common;
using Tiririt.Web.Models;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers
{    
    public class WathcListController : TiriritControllerBase
    {
        private readonly IWatchListService watchListService;

        public WathcListController(IWatchListService watchListService)
        {
            this.watchListService = watchListService;
        }


        /// <summary>
        /// Returns the default watch list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]                
        public ActionResult<WatchListViewModel> Get()
        {
            var result = watchListService.GetWatchList();
            return Ok(result);
        }

        //PUT: WatchList/id/stock/{stockSymbol}
        [HttpPut(RouteConsts.WatchList.AddStock)]
        [ProducesResponseType(200)]
        public ActionResult<WatchListViewModel> PutStock(int id, string symbol)
        {
            var result = watchListService
                .AddStock(id, symbol)
                .ToViewModel();
            return Ok(result);
        }

        [HttpPut(RouteConsts.WatchList.Rename)]
        [ProducesResponseType(200)]
        public ActionResult<WatchListViewModel> RenameWatchList(int id, [FromBody]string newName) 
        {
            var result = watchListService.RenameWatchList(id, newName).ToViewModel();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult<WatchListViewModel> NewWatchList([FromBody]WatchListViewModel watchListModel)
        {
            var result = watchListService
                .NewWatchList(watchListModel.ToDomainModel())
                .ToViewModel();
            return Ok(result);
        }

        [HttpDelete(RouteConsts.WatchList.DeleteWatchList)]
        public IActionResult DeleteWatchList(int id)
        {
            watchListService.DeleteWatchList(id);
            return Ok();
        }
    }
}