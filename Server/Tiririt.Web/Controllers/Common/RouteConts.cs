using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;
using System.Security.Policy;

namespace Tiririt.Web.Common
{
    public static class RouteConsts
    {
        public static class TiriritPost
        {
            public const string UserPostings = "user/{userId}";
            public const string Reply = "{postId}/comment";
            public const string ModifyPost = "{postId}";
            public const string Post = "";
            public const string DeletePost = "";
            public const string Comments = "{postId}/comments";
            public const string LikeDislike = "{postId}/like/{like}";
            public const string PostDetails = "{postId}";
        }

        public static class Stock
        {
            public const string GetStock = "{symbol}";            
        }

        public static class StockQuote
        {
            public const string EndOfDay = "{symbol}/eod";
            public const string EndOfDayChart = "{symbol}/eod/chart";
        }

        public static class WatchList
        {
            public const string NewWatchList = "";
            public const string DeleteWatchList = "{id}";

            public const string Rename = "{id}/name";

            public const string Stocks = "{id}/stocks";            

            public const string DeleteStock = "{id}/stocks/{stockSymbol}";            

        }

        public static class Feed
        {
            public const string UserFeed = "";
            public const string WatchList = "watchlist";
            public const string Mentions = "mentions";
            public const string Subscription = "subscription";
            public const string Trending = "trending";
        }

        public static class Public
        {
            public const string Search = "search";
            public const string Tag = "tag/{tag}";
            public const string Stock = "stock/{symbol}";
        }
    }
}