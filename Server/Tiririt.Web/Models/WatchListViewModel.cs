using System.Collections.Generic;

namespace Tiririt.Web.Models 
{
    public class WatchListViewModel 
    {
        public int WatchListId { get; set; }
        public string WatchListName { get; set; }
        public int UserId { get; set; }
        public IEnumerable<StockViewModel> Stocks { get; set; }
    }
}