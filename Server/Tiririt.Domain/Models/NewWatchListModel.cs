using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiririt.Domain.Models
{
    public class NewWatchListModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Stocks { get; set; }
    }
}
