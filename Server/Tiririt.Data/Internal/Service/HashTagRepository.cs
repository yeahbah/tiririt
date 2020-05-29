using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tiririt.Data.Entities;
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

        public IQueryable<HashTagModel> GetAll()
        {
            var result = dbContext.HashTags
                .AsNoTracking()
                .Select(tag => new HashTagModel {
                    HashTagId = tag.HASH_TAG_ID,
                    HashTagText = tag.HASH_TAG_TEXT                    
                });
            return result;
        }

        public HashTagModel AddHashTag(string tag)
        {
            var hashTag = GetAll()                
                .SingleOrDefault(h => h.HashTagText == tag);
            if (hashTag != null) 
            {
                var newTag = new HASH_TAG 
                {
                    HASH_TAG_TEXT = tag
                };
                dbContext.HashTags.Add(newTag);
                dbContext.SaveChanges();
                hashTag = GetAll()
                    .SingleOrDefault(h => h.HashTagText == tag);
            }
            return hashTag;
        }

        public void AddTagsToPost(int postId, string[] hashTags)
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
            dbContext.SaveChanges();
        }

        public void RemoveTagsFromPost(int postId)
        {
            dbContext.PostHashTags
                .Where(post => post.TIRIRIT_POST_ID == postId)
                .ToList()
                .ForEach(post => {
                    dbContext.PostHashTags.Remove(post);
                });            
        }
    }
}