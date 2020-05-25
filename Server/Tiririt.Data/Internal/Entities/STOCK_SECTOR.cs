using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class STOCK_SECTOR 
    {
        [Key]
        public int STOCK_SECTOR_ID { get; set; }

        [Required]
        public string SECTOR_NAME { get; set; }

        public ICollection<STOCK> Ref_Stocks { get; set; }
    }
}