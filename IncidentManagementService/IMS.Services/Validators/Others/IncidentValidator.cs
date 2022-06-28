using FluentValidation;
using IMS.Core.Dtos;

namespace IMS.ServiceInterface.Validators.Others
{
    class IncidentValidator : AbstractValidator<IncidentDto>
    {
        public IncidentValidator()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .MaximumLength(50);

            
        }
    }
}
