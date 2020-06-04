using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiririt.Data.Entities;

namespace Tiririt.Data.Internal.Entities
{
    public class MENTION
    {
        [Key]
        public int MENTION_ID { get; set; }

        [Required]
        public int TIRIRIT_POST_ID { get; set; }

        [Required]
        public int TIRIRIT_USER_ID { get; set; }

        [Range(0, 1)]
        public int DELETED_IND { get; set; }

        public virtual TIRIRIT_POST Ref_TiriritPost { get; set; }
        public virtual TIRIRIT_USER Ref_TiriritUser { get; set; }
    }
}
