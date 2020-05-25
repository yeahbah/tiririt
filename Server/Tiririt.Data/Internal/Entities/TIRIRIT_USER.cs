using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiririt.Data.Entities
{
    internal class TIRIRIT_USER
    {
        [Key]
        public int TIRIRIT_USER_ID { get; set; }

        [Required]
        public string USER_ID { get; set; }

        [Required]
        public string EMAIL_ADDRESS { get; set; }

        [Required]
        public string PASSWORD { get; set; }

        [Required]
        public string FIRST_NAME { get; set; }

        [Required]
        public string LAST_NAME { get; set; }
        public DateTime? BIRTH_DT { get; set; }

        [Required]
        public DateTime REGISTER_DT { get; set; }

        public ICollection<TIRIRIT_POST> Ref_TiriritPosts { get; set; }
    }
}