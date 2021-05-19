
using System;
using Tiririt.Core.CQRS;
using Tiririt.Core.Enums;

namespace Tiririt.App.Models
{
    public record PostViewModel : BaseResponse
    {
        public int PostId { get; init; }
        public string PostText { get; init; }
        public int LikeCount { get; init; }
        public int DislikeCount { get; init; }
        public int UserId { get; init; }
        public string UserName { get; init; }
        public int? OriginalPostId { get; init; }
        public DateTime PostDate { get; init; }
        public BullBearLevel? BullBearLevel { get; init; }
        public int CommentCount { get; init; }
        public bool LikedByUser { get; init; }
    }
}