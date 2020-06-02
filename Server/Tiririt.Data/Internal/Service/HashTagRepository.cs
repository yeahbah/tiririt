using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Service
{
    internal class HashTagRepository : IHashTagRepository
    {
        private readonly TiriritDbContext dbContext;

        public HashTagRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IQueryable<HashTagModel> GetAll()
        {
            var result = dbContext.HashTags
                .AsNoTracking()
                .Select(tag => new HashTagModel
                {
                    HashTagId = tag.HASH_TAG_ID,
                    HashTagText = tag.HASH_TAG_TEXT
                });
            return result;
        }

        public async Task<HashTagModel> AddHashTag(string tag)
        {
            var hashTag = await GetAll()                
                .SingleOrDefaultAsync(h => h.HashTagText == tag);
            if (hashTag != null) 
            {
                var newTag = new HASH_TAG 
                {
                    HASH_TAG_TEXT = tag
                };
                dbContext.HashTags.Add(newTag);
                await dbContext.SaveChangesAsync();
                hashTag = await GetAll()
                    .SingleOrDefaultAsync(h => h.HashTagText == tag);
            }
            return hashTag;
        }

        public async Task AddTagsToPost(int postId, string[] hashTags)
        {                    
            foreach(var tag in hashTags)
            {
                var hashTag = GetAll()
                    .SingleOrDefault(t => t.HashTagText == tag);
                if (hashTag == null) 
                {
                    var newHashTag = new HASH_TAG 
                    {
                        HASH_TAG_TEXT = tag
                    };
                    dbContext.HashTags.Add(newHashTag);
                    var link = new POST_HASH_TAG 
                    {
                        Ref_HashTag = newHashTag,                    
                        TIRIRIT_POST_ID = postId
                    };
                    dbContext.PostHashTags.Add(link);                    
                }
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveTagsFromPost(int postId, bool permanent = false)
        {
            var tags = dbContext.PostHashTags
                .Where(post => post.TIRIRIT_POST_ID == postId);
                
            if (permanent)
            {
                var tagList = await tags.ToListAsync();
                tagList
                    .ForEach(tag => {                    
                        dbContext.PostHashTags.Remove(tag);
                    });            
            }
            else
            {
                var tagList = await tags.ToListAsync();
                tagList
                    .ForEach(tag => {                    
                        tag.DELETED_IND = 1;
                    });            
            }

            await dbContext.SaveChangesAsync();
        }        

        public async Task<HashTagModel> Get(int id)
        {
            return await GetAll()
                .SingleOrDefaultAsync(tag => tag.HashTagId == id);        
        }
        
    }
}