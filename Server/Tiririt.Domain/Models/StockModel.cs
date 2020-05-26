namespace Tiririt.Domain.Models
{
    public class StockModel
    {
        public int StockId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int? SectorId { get; set; }
    }
}