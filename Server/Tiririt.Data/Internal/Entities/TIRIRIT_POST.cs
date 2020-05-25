using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    internal class TIRIRIT_POST : ENTITY_BASE
    {
        [Key]
        public int TIRIRIT_POST_ID { get; set; }

        [Required]
        public string POST_TEXT { get; set; }

        [Required]
        public int TIRIRIT_USER_ID { get; set; }

        public int? RESPONSE_TO_POST_ID { get; set; }

        public virtual TIRIRIT_USER Ref_PostedBy { get; set; }

        public virtual TIRIRIT_POST Ref_TiriritPost { get; set; }

        public virtual ICollection<TIRIRIT_POST> Ref_Responses { get; set; }

        public virtual ICollection<POST_HASH_TAG> Ref_HashTags { get; set; }

        public virtual ICollection<POST_STOCK> Ref_Stocks { get; set; }
    }
}