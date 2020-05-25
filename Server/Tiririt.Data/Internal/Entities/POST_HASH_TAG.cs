using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class POST_HASH_TAG 
    {
        [Key]
        public int POST_HASH_TAG_ID { get; set; }

        [Required]
        public string HASH_TAG { get; set; }

        [Required]
        public int TIRIRIT_POST_ID { get; set; }

        public ICollection<TIRIRIT_POST> Ref_ManyTiriritPost { get; set; }
    }
}