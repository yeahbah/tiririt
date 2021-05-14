using System;
using Tiririt.Core.Collection;

namespace Tiririt.App
{
    public record BasePagingResultRequest
    {
        public PagingParam PagingParam { get; set; }
    }
}
