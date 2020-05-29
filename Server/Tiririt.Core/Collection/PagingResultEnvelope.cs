using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Dynamic.Core;

namespace Tiririt.Core.Collection
{
    public class PagingResultEnvelope<T>
    {        
        private PagingResultEnvelope(IEnumerable<T> data, PagingParam pagingParam)
        {
            Data = data;
            PageIndex = pagingParam.PageIndex;
            PageSize = pagingParam.PageSize;
            SortColumn = pagingParam.SortColumn;
            SortOrder = pagingParam.SortOrder;
            FilterColumn = pagingParam.FilterColumn;
            FilterQuery = pagingParam.FilterQuery;
            TotalCount = data.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        }

        public static PagingResultEnvelope<T> ToPagingEnvelope(IQueryable<T> data, PagingParam pagingParam)
        {
            if (!string.IsNullOrEmpty(pagingParam.SortColumn) && IsValidProperty<T>(pagingParam.SortColumn)) 
            {
                pagingParam.SortOrder = !string.IsNullOrEmpty(pagingParam.SortOrder) && pagingParam.SortOrder.ToUpper() == "ASC" ? "ASC" : "DESC";
                data = data.OrderBy($"{pagingParam.SortColumn} {pagingParam.SortOrder}");
            }

            if (!string.IsNullOrEmpty(pagingParam.FilterColumn) && !string.IsNullOrEmpty(pagingParam.FilterQuery) 
                && IsValidProperty<T>(pagingParam.FilterColumn))
            {
                var filter = string.Format("{0}.Contains(\"{1}\")", pagingParam.FilterColumn, pagingParam.FilterQuery);
                data = data.Where(filter);
            }

            data
                .Skip(pagingParam.PageSize * pagingParam.PageIndex)
                .Take(pagingParam.PageSize);            
                
            return new PagingResultEnvelope<T>(data, pagingParam);
        }

        private static bool IsValidProperty<T>(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (prop == null && throwExceptionIfNotFound)
            {
                throw new NotSupportedException($"ERROR: Property {propertyName} does not exist.");                
            }
            return prop != null;
        }

        public IEnumerable<T> Data { get; set; }        
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public string SortColumn { get; private set; }
        public string SortOrder { get; private set; }
        public string FilterColumn { get; private set; }
        public string FilterQuery { get; private set; }
        
    }
}