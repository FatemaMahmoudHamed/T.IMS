using FluentValidation;
using IMS.Core.Dtos;

namespace IMS.ServiceInterface.Validators.Others
{
    class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .MaximumLength(50);
        }
    }
}
