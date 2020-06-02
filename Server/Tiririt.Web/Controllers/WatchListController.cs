using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<WatchListViewModel>> Get()
        {
            var result = await watchListService
                .GetWatchList();           
            return Ok(result.Select(w => w.ToViewModel()));
        }

        //PUT: WatchList/id/stock/{stockSymbol}
        [HttpPut(RouteConsts.WatchList.AddStock)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<WatchListViewModel>> PutStock(int id, string symbol)
        {
            var result = await watchListService
                .AddStock(id, symbol);
            return Ok(result.ToViewModel());
        }

        [HttpPut(RouteConsts.WatchList.Rename)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<WatchListViewModel>> RenameWatchList(int id, [FromBody]string newName) 
        {
            var result = await watchListService.RenameWatchList(id, newName);
            return Ok(result.ToViewModel());
        }

        //[HttpPost]
        //[ProducesResponseType(200)]
        //public async Task<ActionResult<WatchListViewModel>> NewWatchList([FromBody]WatchListViewModel watchListModel)
        //{
        //    var result = await watchListServicer
        //        .NewWatchList(watchListModel.ToDomainModel());
        //    return Ok(result.ToViewModel());
        //}

        [HttpDelete(RouteConsts.WatchList.DeleteWatchList)]
        public async Task<IActionResult> DeleteWatchList(int id)
        {
            await watchListService.DeleteWatchList(id);
            return Ok();
        }
    }
}