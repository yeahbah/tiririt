using System;
using Tiririt.Core.Collection;

namespace Tiririt.Core.CQRS
{
    public record BasePagingResultRequest
    {
        public PagingParam PagingParam { get; set; }
    }
}
