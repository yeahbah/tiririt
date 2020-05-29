using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    public class STOCK_SECTOR : ENTITY_BASE
    {
        [Key]
        public int STOCK_SECTOR_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string SECTOR_NAME { get; set; }

        public virtual ICollection<STOCK> Ref_Stocks { get; set; }
    }
}