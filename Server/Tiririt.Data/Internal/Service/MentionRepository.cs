using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tiririt.Data.Internal.Entities;
using Tiririt.Data.Service;

namespace Tiririt.Data.Internal.Service
{
    public class MentionRepository : IMentionRepository
    {
        private readonly TiriritDbContext dbContext;

        public MentionRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPostMention(int postId, string[] userNames)
        {
            var users = await dbContext.Users
                .Where(user => userNames.Contains(user.UserName))
                .ToListAsync();
            if (!users.Any()) return;

            users.ForEach(user =>
            {
                var mention = new MENTION
                {
                    TIRIRIT_POST_ID = postId,
                    TIRIRIT_USER_ID = user.Id
                };
                dbContext.Mentions.Add(mention);
            });
            
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveMentions(int postId, bool permanent = false)
        {
            var mentions = await dbContext.Mentions
                .Where(mention => mention.TIRIRIT_POST_ID == postId)
                .ToListAsync();
            if (!mentions.Any()) return;

            if (permanent)
            {
                dbContext.Mentions.RemoveRange(mentions);
            }
            else
            {
                mentions.ForEach(mention =>
                {
                    mention.DELETED_IND = 1;
                });
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
