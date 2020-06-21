using Microsoft.VisualBasic;

namespace Tiririt.Web.Common
{
    public static class RouteConsts
    {
        public static class TiriritPost
        {
            public const string UserPostings = "user/{userId}";
            public const string Reply = "{postId}/reply";
            public const string ModifyPost = "{postId}";
            public const string NewPost = "";
            public const string DeletePost = "";
            public const string Responses = "{postId}/responses";
            public const string LikeDislike = "{postId}/like/{like}";            

        }

        public static class Stock
        {
            public const string GetStock = "{symbol}";
        }

        public static class StockQuote
        {
            public const string EndOfDay = "stock/{symbol}/eod";
        }

        public static class WatchList
        {
            public const string NewWatchList = "";
            public const string DeleteWatchList = "{id}";

            public const string Rename = "{id}/name";

            public const string Stocks = "{id}/stocks";

            public const string DeleteStock = "{id}/stocks/{symbol}";

        }
    }
}