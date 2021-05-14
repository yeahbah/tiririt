
using System;
using Tiririt.Core.Enums;

namespace Tiririt.App.Models
{
    public class PostViewModel 
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? OriginalPostId { get; set; }
        public DateTime PostDate { get; set; }
        public BullBearLevel? BullBearLevel { get; set; }
        public int CommentCount { get; set; }
        public bool LikedByUser { get; set; }
    }
}