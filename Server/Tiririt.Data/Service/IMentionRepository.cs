using System.Threading.Tasks;

namespace Tiririt.Data.Service
{
    public interface IMentionRepository
    {
        Task AddPostMention(int postId, string[] userNames);
        Task RemoveMentions(int value, bool permanent = false);
    }
}
