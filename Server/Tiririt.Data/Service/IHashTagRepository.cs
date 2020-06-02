using System.Threading.Tasks;
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
        Task AddTagsToPost(int postId, string[] tags);

        /// <summary>
        /// Unlink tags from post
        /// </summary>
        /// <param name="postId"></param>
        Task RemoveTagsFromPost(int postId, bool permanent = false);

        /// <summary>
        /// Add a single has tag
        /// </summary>
        /// <param name="hashTag"></param>
        /// <returns></returns>        
        Task<HashTagModel> AddHashTag(string hashTag);
    }
}