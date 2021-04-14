using FluentValidation;
using Nursery.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursery.Application.Account.Registration
{
	public class RegistrationValidation : AbstractValidator<RegistrationCommand>
	{
		public RegistrationValidation()
		{
			RuleFor(x => x.DisplayName).NotEmpty()
				.WithMessage("Поле не можу бути пустим");
			RuleFor(x => x.Email).NotEmpty()
				.WithMessage("Поле не можу бути пустим")
				.EmailAddress()
				.WithMessage("Пошту вказано не коректно");
			RuleFor(x => x.Password).Password();
		}
	}
}
