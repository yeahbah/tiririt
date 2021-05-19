using FluentValidation;
using Tiririt.App.Post.Commands;

namespace Tiririt.App.Post.Validation
{
    public class AddOrModifyPostCommandValidator : AbstractValidator<AddOrModifyPostCommand>
    {
        public AddOrModifyPostCommandValidator()
        {
            RuleFor(x => x.PostText)
                .NotEmpty();            
        }
    }
}
