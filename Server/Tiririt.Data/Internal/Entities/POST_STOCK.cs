using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    public class POST_STOCK : ENTITY_BASE
    {
        [Key]
        public int POST_STOCK_ID { get; set; }

        [Required]
        public int TIRIRIT_POST_ID { get; set; }

        [Required]        
        public int STOCK_ID { get; set; }

        public virtual TIRIRIT_POST Ref_TiriritPost { get; set; }

        public virtual STOCK Ref_Stock { get; set; }

        // public ICollection<TIRIRIT_POST> Ref_ManyPosts { get; set; }

        // public ICollection<STOCK> Ref_ManyStocks { get; set; }

    }
}