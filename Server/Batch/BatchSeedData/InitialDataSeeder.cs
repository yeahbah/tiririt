using System.Threading.Tasks;
using Tiririt.Data.Entities;

namespace BatchSeedData
{
    public class InitialDataSeeder : DataSeederBase
    {
        public async static Task Execute()
        {
            var dbContext = CreateDbContext();

            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "Investments" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "PhilEconomy" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "USMarket" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "ForSale" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "TradeIdea" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "Swerte" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "Malas" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "KumikitangKabuhayan" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "FundamentalAnalysis" });
            dbContext.HashTags.Add(new HASH_TAG { HASH_TAG_TEXT = "TechnicalAnalysis" });

            await dbContext.SaveChangesAsync();
        }
    }
}
