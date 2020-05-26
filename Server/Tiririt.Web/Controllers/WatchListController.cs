using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Service;
using Tiririt.Web.Models;

namespace Tiririt.Web.Controllers
{    
    public class WathcListController : TiriritControllerBase
    {
        private readonly IWatchListService watchListService;

        public WathcListController(IWatchListService watchListService)
        {
            this.watchListService = watchListService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetWatchList()
        {
            var result = watchListService.GetWatchList();
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult PutStock(int id, string stockSymbol)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult RenameWatchList(int id, string newName) 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult NewWatchList([FromBody]WatchListViewModel watchListModel)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWatchList(int id)
        {
            return Ok();
        }
    }
}