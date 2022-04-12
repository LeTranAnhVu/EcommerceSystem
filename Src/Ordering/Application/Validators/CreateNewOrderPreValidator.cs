using Application.Commands;
using FluentValidation;

namespace Application.Validators;

public class CreateNewOrderPreValidator : AbstractValidator<CreateNewOrderCommand>
{
    public CreateNewOrderPreValidator()
    {
        RuleFor(c => c.ItemIds).NotEmpty();
    } 
}