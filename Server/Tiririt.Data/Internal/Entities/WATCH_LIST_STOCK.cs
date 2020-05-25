using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class WATCH_LIST_STOCK
    {
        [Key]
        public int WATCH_LIST_STOCK_ID { get; set; }

        [Required]
        public string STOCK_ID { get; set; }

        [ForeignKey("STOCK_ID")]
        public STOCK Ref_Stock { get; set; }
    }
}