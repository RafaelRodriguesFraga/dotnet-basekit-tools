using DotnetBaseKit.Application.DTOs;
using FluentValidation;

namespace DotnetBaseKit.Application.Validations
{
    public class ExampleRequestDtoContract : AbstractValidator<ExampleRequestDto>
    {
        public ExampleRequestDtoContract()
        {
            RuleFor(x => x.ExampleProperty)
                .NotEmpty().WithMessage("ExampleProperty is required.")
                .MaximumLength(100).WithMessage("ExampleProperty must not exceed 100 characters.");
        }
    }
}