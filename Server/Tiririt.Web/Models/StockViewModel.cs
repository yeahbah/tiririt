namespace Tiririt.Web.Models
{
    public class StockViewModel 
    {
        public int StockId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int? SectorId { get; set; }
    }
}