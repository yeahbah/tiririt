using System;
using System.Threading.Tasks;

namespace Tiririt.Core.CQRS
{
    public interface IValidationHandler
    {
    }

    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResult> Validate(T request);
    }
}
