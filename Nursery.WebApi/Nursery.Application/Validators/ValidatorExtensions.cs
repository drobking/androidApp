using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursery.Application.Validators
{
	public static class ValidatorExtensions
	{
		public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			var options = ruleBuilder
				.NotEmpty().WithMessage("Поле не можу бути пустим")
				.MinimumLength(6).WithMessage("Пароль повинен містити щонайменше 6 символів")
				.Matches("[A-Z]").WithMessage("Пароль повинен містити 1 велику літеру")
				.Matches("[0-9]").WithMessage("Пароль повинен містити номер")
				.Matches("[^a-zA-Z0-9]").WithMessage("Пароль повинен містити спецсимволи");

			return options;
		}
	}
}
