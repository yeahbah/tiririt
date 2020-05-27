using System;
using System.Collections.Generic;
using Tiririt.Core.Enums;

namespace Tiririt.Domain.Models
{
    public class PostModel 
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public int UserId { get; set; }
        public int? ResponseToPostId { get; set; }

        public DateTime PostDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string BullBearLevel { get; set; }
        public IEnumerable<UserModel> LikedBy { get; set; }
        public IEnumerable<UserModel> DislikedBy { get; set; }
        public IEnumerable<StockModel> RelatedStocks { get; set;}
        public IEnumerable<HashTagModel> Tags { get; set; }
    }
}