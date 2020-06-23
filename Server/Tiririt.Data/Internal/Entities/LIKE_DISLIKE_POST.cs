using System.ComponentModel.DataAnnotations;

namespace Tiririt.Data.Entities
{
    public class LIKE_DISLIKE_POST 
    {
        //[Key]
        //public int LIKE_DISLIKE_POST_ID { get; set; }

        [Required]
        public int TIRIRIT_USER_ID { get; set; }

        [Required]
        public int TIRIRIT_POST_ID { get; set; }

        [Range(0, 1)]        
        public int USER_LIKE_IND { get; set; }

        [Range(0, 1)]
        public int DELETED_IND { get; set; }

        public virtual TIRIRIT_USER Ref_TiriritUser { get; set; }
        public virtual TIRIRIT_POST Ref_TiriritPost { get; set; }
    }
}