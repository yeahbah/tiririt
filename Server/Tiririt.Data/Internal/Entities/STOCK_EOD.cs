using System;
using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    internal class STOCK_QUOTE : ENTITY_BASE
    {
        [Key]
        public int STOCK_EOD_ID {get; set;}

        [Required]
        public DateTime TRADE_DATE { get; set; }
        
        [Required]
        public decimal OPEN { get; set; }

        [Required]
        public decimal HIGH { get; set; }

        [Required]
        public decimal LOW { get; set; }

        [Required]
        public decimal CLOSE { get; set; }

        public decimal? NET_FOREIGN_BUY { get; set; }

        [Required]        
        public int STOCK_ID { get; set; }

        public virtual STOCK Ref_Stock { get; set; }

    }
}