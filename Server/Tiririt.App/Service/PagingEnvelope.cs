using System.Collections.Generic;

namespace Tiririt.App.Service
{
    public class PagingEnvelope<T>
    {
        public int PageSize { get; private set; }
        public int PageIndex { get; private set; }
        public string SortColumn { get; private set; }
        public string SortOrder { get; private set; }
        public string FilterColumn { get; private set; }
        public string FilterQuery { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<T> Data { get; private set; }
    }
}