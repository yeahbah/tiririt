using System;
using System.Linq;
using Tiririt.Core.Enums;
using Tiririt.Core.Identity;
using Tiririt.Domain.Models;

namespace Tiririt.App.Models.Mappings
{    
    public static class PostModelMapping
    {
        public static PostViewModel ToViewModel(this PostModel value, ICurrentPrincipal currentPrincipal)
        {
            if (value == null) return null;

            var likedByUser = false;
            if (currentPrincipal != null)
            {
                likedByUser = currentPrincipal.GetUserId() == null ? false : value.LikedBy.Any(u => u.UserId == currentPrincipal.GetUserId());
            }
            return new PostViewModel
            {
                BullBearLevel = (BullBearLevel)Enum.Parse(typeof(BullBearLevel), value.BullBearLevel),
                DislikeCount = value.DislikedBy.Count(),
                LikeCount = value.LikedBy.Count(),
                PostDate = value.PostDate,
                PostId = value.PostId,
                PostText = value.PostText,
                UserId = value.UserId,
                UserName = value.UserName,
                CommentCount = value.Comments == null ? 0 : value.Comments.Count(),
                OriginalPostId = value.OriginalPostId,
                LikedByUser = likedByUser
            };
        }
    }
    
}
