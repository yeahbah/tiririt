using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    internal class BULL_BEAR_LEVEL_CODE 
    {
        [Key]
        public int BULL_BEAR_LEVEL_CODE_ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string BULL_BEAR_LEVEL_CD { get; set; }

        public virtual ICollection<TIRIRIT_POST> Ref_TiriritPosts { get; set; }
    }
}