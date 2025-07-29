using FluentValidation;
using Application.Queries;

namespace Application.Validators
{
    public class GetGreetingQueryValidator : AbstractValidator<GetGreetingQuery>
    {
        public GetGreetingQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}