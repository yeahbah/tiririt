using System;
using System.Collections.Generic;

namespace Tiririt.Web.Models
{
    public class ChartSeriesModel
    {
        public DateTime Time { get; set; }
        public decimal Value { get; set; }
    }

    //public class StockChartDataModel
    //{
    //    public string Name { get; set; }
    //    public IEnumerable<ChartSeriesModel> Series { get; set; }
    //}

    public class ChartDataViewModel
    {
        public IEnumerable<ChartSeriesModel> ChartData { get; set; }
    }
}
