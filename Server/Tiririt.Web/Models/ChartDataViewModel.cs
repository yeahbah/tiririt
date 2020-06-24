using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiririt.Web.Models
{
    public class ChartSeriesModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }

    public class StockChartDataModel
    {
        public string Name { get; set; }
        public IEnumerable<ChartSeriesModel> Series { get; set; }
    }

    public class ChartDataViewModel
    {
        public IEnumerable<StockChartDataModel> ChartData { get; set; }
    }
}
