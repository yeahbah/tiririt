using System;
using System.Net;

namespace Tiririt.Core.CQRS
{
    public record BaseResponse
    {
        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public string ErrorMessage { get; init; }
    }
}
