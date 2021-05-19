using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tiririt.Core.CQRS;

namespace Tiririt.App.PipelineBehaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : BaseResponse, new()
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = this.validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();
            
            if (failures.Any())
            {
                //var result = ValidationResult.Fail(failures);
                //throw new ValidationException(failures);
                return new TResponse {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = new ValidationException(failures).Message
                };
            }

            return await next();
        } 
    }
}
