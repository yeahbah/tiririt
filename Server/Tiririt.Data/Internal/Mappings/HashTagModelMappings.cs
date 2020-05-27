using Tiririt.Data.Entities;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Mappings
{
    internal static class HashTagModelMapping
    {
        public static HashTagModel ToDomainModel(this HASH_TAG value)
        {
            if (value == null) return null;

            return new HashTagModel
            {
                HashTagId = value.HASH_TAG_ID,
                HashTagText = value.HASH_TAG_TEXT,
                PostId = value.TIRIRIT_POST_ID
            };
        }
    }
}