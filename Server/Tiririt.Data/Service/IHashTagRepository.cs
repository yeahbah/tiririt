using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IHashTagRepository
    {
        /// <summary>
        /// Link a post to tags
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="tags"></param>
        void AddTagsToPost(int postId, string[] tags);

        /// <summary>
        /// Unlink tags from post
        /// </summary>
        /// <param name="postId"></param>
        void RemoveTagsFromPost(int postId);

        /// <summary>
        /// Add a single has tag
        /// </summary>
        /// <param name="hashTag"></param>
        /// <returns></returns>
        HashTagModel AddHashTag(string hashTag);
    }
}