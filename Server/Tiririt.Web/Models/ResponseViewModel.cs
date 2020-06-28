using System;

namespace Tiririt.Web.Models
{
    public class ResponseViewModel 
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}