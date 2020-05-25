using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class TIRIRIT_POST 
    {
        [Key]
        public int POST_ID { get; set; }

        [Required]
        public string POST_TEST { get; set; }

        [Required]
        public int USER_ID { get; set; }

        public int? RESPONSE_TO_POST_ID { get; set; }

        [ForeignKey("USER_ID")]
        public TIRIRIT_USER Ref_PostedBy { get; set; }

        public ICollection<TIRIRIT_POST> Ref_Responses { get; set; }

        public ICollection<POST_HASH_TAG> Ref_HashTags { get; set; }

        public ICollection<STOCK> Ref_Stocks { get; set; }
    }
}