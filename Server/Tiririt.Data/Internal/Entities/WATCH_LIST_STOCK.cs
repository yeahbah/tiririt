using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    internal class WATCH_LIST_STOCK : ENTITY_BASE
    {
        [Key]
        public int WATCH_LIST_STOCK_ID { get; set; }

        [Required]
        public string STOCK_ID { get; set; }

        public virtual STOCK Ref_Stock { get; set; }

        public virtual WATCH_LIST Ref_WatchList { get; set; }
    }
}