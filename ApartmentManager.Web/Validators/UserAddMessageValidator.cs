using ApartmentManager.Web.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Validators
{
    public class UserAddMessageValidator : AbstractValidator<MessageDto>
    {
        public UserAddMessageValidator()
        {
            RuleFor(x => x.Subject).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Content).NotNull().WithMessage("Bu alan boş geçilemez");
        }
    }
}
