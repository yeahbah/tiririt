using System;
namespace Tiririt.Core.CQRS
{
    public record ValidationResult
    {
        public bool IsSuccessful { get; init; } = true;
        public string Error { get; init; }
        public static ValidationResult Success => new ValidationResult();
        public static ValidationResult Fail(string error) => new ValidationResult { IsSuccessful = false, Error = error };
    }
}
