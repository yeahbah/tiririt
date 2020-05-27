using System.Linq;
using Tiririt.Domain.Models;

namespace Tiririt.Web.Models.Mappings
{
    public static class ResponseModelMapping
    {
        public static ResponseViewModel ToResponseViewModel(this PostModel value)
        {
            if (value == null) return null;

            return new ResponseViewModel
            {                
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