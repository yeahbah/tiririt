using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    public class WATCH_LIST : ENTITY_BASE
    {
        [Key]
        public int WATCH_LIST_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string WATCH_LIST_NAME { get; set; }

        [Required]
        public int TIRIRIT_USER_ID { get; set; }

        public virtual TIRIRIT_USER Ref_TiriritUser { get; set; }

        public virtual ICollection<WATCH_LIST_STOCK> Ref_Stocks { get; set; }
    }
}