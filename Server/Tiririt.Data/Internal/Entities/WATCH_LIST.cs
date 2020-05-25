using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class WATCH_LIST
    {
        [Key]
        public int WATCH_LIST_ID { get; set; }

        public string WATCH_LIST_NAME { get; set; }

        [Required]
        public int TIRIRIT_USER_ID { get; set; }

        [ForeignKey("TIRIRIT_USER_ID")]
        public TIRIRIT_USER Ref_TiriritUser { get; set; }

        public ICollection<WATCH_LIST_STOCK> Ref_Stocks { get; set; }
    }
}