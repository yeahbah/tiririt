using System.Linq;
using Tiririt.Domain.Models;

namespace Tiririt.App.Models.Mappings
{
    internal static class WatchListModelMapping 
    {
        public static WatchListViewModel ToViewModel(this WatchListModel value)
        {
            if (value == null) return null;

            return new WatchListViewModel
            {
                WatchListId = value.WatchListId,
                WatchListName = value.WatchListName,
                UserId = value.UserId,
                Stocks = value.Stocks.Select(s => s.ToViewModel())
            };
        }

        //public static WatchListModel ToDomainModel(this WatchListViewModel value)
        //{
        //    if (value == null) return null;

        //    return new WatchListModel
        //    {
        //        Stocks = value.Stocks.Select(s => s.ToDomainModel()),
        //        UserId = value.UserId,
        //        WatchListId = value.WatchListId,
        //        WatchListName = value.WatchListName
        //    };
        //}
    }
}