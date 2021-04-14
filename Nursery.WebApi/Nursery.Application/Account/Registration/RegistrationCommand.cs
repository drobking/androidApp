using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursery.Application.Account.Registration
{
	public class RegistrationCommand : IRequest<UserViewModel>
	{
		public string DisplayName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}
}
