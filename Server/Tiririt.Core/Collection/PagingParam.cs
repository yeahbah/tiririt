namespace Tiririt.Core.Collection
{
    public class PagingParam
    {                
        private int _pageIndex;
        public int PageIndex 
        { 
            get => _pageIndex;
             
            set
            {
                _pageIndex = value <= 0 ? 0 : value;
            }
        }

        private int _pageSize;
        private int maxPageSize = 100;
        public int PageSize 
        { 
            get => _pageSize;
            
            set
            {
                _pageSize = value <= 0 ? 10 : value;  
                if (value > maxPageSize)  
                {
                    _pageSize = maxPageSize;
                }
            } 
        }

        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string FilterColumn { get; set; }
        public string FilterQuery { get; set; }
    }
}