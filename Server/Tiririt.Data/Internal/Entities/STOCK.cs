using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class STOCK
    {
        [Key]
        public int STOCK_ID { get; set; }

        [Required]
        public string NAME { get; set; }

        [Required]
        public int SECTOR_ID { get; set; }
        
        [ForeignKey("SECTOR_ID")]
        public STOCK_SECTOR Ref_Sector { get; set; }
    }
}