using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    public class TIRIRIT_USER : ENTITY_BASE
    {
        [Key]
        public int TIRIRIT_USER_ID { get; set; }

        [Required]
        public string USER_NAME { get; set; }

        [Required]
        public string EMAIL_ADDRESS { get; set; }

        [Required]
        public string PASSWORD { get; set; }

        [Required]
        [MaxLength(50)]
        public string FIRST_NAME { get; set; }

        [Required]
        [MaxLength(50)]
        public string LAST_NAME { get; set; }
        public DateTime? BIRTH_DT { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime REGISTER_DT { get; set; }

        public virtual ICollection<TIRIRIT_POST> Ref_TiriritPosts { get; set; }
        public virtual ICollection<WATCH_LIST> Ref_WatchLists { get; set; }

        public virtual ICollection<LIKE_DISLIKE_POST> Ref_LikeDislikePosts { get; set;}
    }
}