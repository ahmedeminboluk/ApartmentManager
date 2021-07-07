using ApartmentManager.Web.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.TcNo).Length(11, 11).WithMessage("11 karakter girişi yapınız!").NotNull().WithMessage("Boş bırakılamaz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir Email giriniz!").NotNull().WithMessage("Boş bırakılamaz!");
        }
    }
}
