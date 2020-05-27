using System;
using System.Linq;
using Tiririt.Core.Enums;
using Tiririt.Domain.Models;

namespace Tiririt.Web.Models.Mappings
{
    public static class PostModelMapping
    {
        public static PostViewModel ToViewModel(this PostModel value)
        {
            if (value == null) return null;

            return new PostViewModel 
            {
                BullBearLevel = (BullBearLevel)Enum.Parse(typeof(BullBearLevel), value.BullBearLevel),
                DislikeCount = value.DislikedBy.Count(),
                LikeCount = value.LikedBy.Count(),
                PostDate = value.PostDate,
                PostId = value.PostId,
                PostText = value.PostText,
                UserId = value.UserId                
            };
        }                
    }
}