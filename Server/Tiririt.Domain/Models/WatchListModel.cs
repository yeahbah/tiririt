using System.Collections.Generic;

namespace Tiririt.Domain.Models
{
    public class WatchListModel 
    {
        public int WatchListId { get; set; }
        public string WatchListName { get; set; }
        public int UserId { get; set; }
        public IEnumerable<StockModel> Stocks { get; set; }
    }
}