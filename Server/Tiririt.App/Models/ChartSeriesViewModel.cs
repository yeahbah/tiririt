using System;
using System.Collections.Generic;

namespace Tiririt.App.Models
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

    public class ChartSeriesViewModel
    {
        public IEnumerable<ChartSeriesModel> ChartData { get; set; }
    }
}
