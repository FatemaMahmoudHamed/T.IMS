using FluentValidation;
using IMS.Core.Dtos;

namespace IMS.ServiceInterface.Validators
{
    public class BaseValidator : AbstractValidator<BaseDto<int>>
    {
        public BaseValidator()
        {

        }
    }
}
