using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    internal class POST_HASH_TAG : ENTITY_BASE
    {
        [Key]
        public int POST_HASH_TAG_ID { get; set; }

        [Required]
        public int HASH_TAG_ID { get; set; }

        [Required]
        public int TIRIRIT_POST_ID { get; set; }

        public virtual TIRIRIT_POST Ref_TiriritPost { get; set; }
        public virtual HASH_TAG Ref_HashTag { get; set; }

    }
}