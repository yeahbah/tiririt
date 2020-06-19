using System.Collections.Generic;

namespace Tiririt.Web.Models
{
    public class NewWatchListViewModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Stocks { get; set; }
    }
}
