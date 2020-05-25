using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class POST_STOCK
    {
        [Key]
        public int POST_STOCK_ID { get; set; }

        [Required]
        public int TIRIRIT_POST_ID { get; set; }

        [Required]        
        public int STOCK_ID { get; set; }

        public ICollection<TIRIRIT_POST> Ref_ManyPosts { get; set; }

        public ICollection<STOCK> Ref_ManyStocks { get; set; }

    }
}