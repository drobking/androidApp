using FluentValidation;
using Nursery.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursery.Application.Account.Login
{
	public class LoginValidation : AbstractValidator<LoginCommand>
	{
		public LoginValidation()
		{

			RuleFor(x => x.Email).NotEmpty()
				.WithMessage("Поле не можу бути пустим");
			RuleFor(x => x.Password).NotEmpty()
				.WithMessage("Поле не можу бути пустим");
		}
	}
}
