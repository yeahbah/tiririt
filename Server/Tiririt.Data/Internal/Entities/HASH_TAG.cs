using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class HASH_TAG : ENTITY_BASE
    {
        [Key]
        public int HASH_TAG_ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string HASH_TAG_TEXT { get; set; }

        [Required]
        public int TIRIRIT_POST_ID { get; set; }

        public virtual ICollection<POST_HASH_TAG> Ref_TiriritPosts { get; set; }
    }
}