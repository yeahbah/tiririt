using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class STOCK : ENTITY_BASE
    {
        [Key]
        public int STOCK_ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string SYMBOL { get; set; }

        [Required]
        [MaxLength(200)]
        public string NAME { get; set; }

        [Required]
        public int SECTOR_ID { get; set; }
        
        public virtual STOCK_SECTOR Ref_Sector { get; set; }

        public virtual ICollection<POST_STOCK> Ref_TiriritPosts { get; set; }

        public virtual ICollection<STOCK_QUOTE> Ref_StockQuotes { get; set; }
    }
}