using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nursery.Application.Exceptions;
using Nursery.Application.Interfaces;
using Nursery.Domain;
using Nursery.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nursery.Application.Account.Registration
{
	public class RegistrationHandler : IRequestHandler<RegistrationCommand, UserViewModel>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IJwtGenerator _jwtGenerator;
		private readonly EFDataContext _context;

		public RegistrationHandler(EFDataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
		{
			_context = context;
			_userManager = userManager;
			_jwtGenerator = jwtGenerator;
		}

		public async Task<UserViewModel> Handle(RegistrationCommand request, CancellationToken cancellationToken)
		{
			if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
			{
				throw new RestException(HttpStatusCode.BadRequest, new { Email =
					new string[] { "Email already exist" } 
				});
			}

			//if (await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
			//{
			//	throw new RestException(HttpStatusCode.BadRequest, new { UserName = "UserName already exist" });
			//}

			var user = new AppUser
			{
				DisplayName = request.DisplayName,
				Email = request.Email,
				UserName = request.Email
			};

			var result = await _userManager.CreateAsync(user, request.Password);

			if (result.Succeeded)
			{
				return new UserViewModel
				{
					DisplayName = user.DisplayName,
					Token = _jwtGenerator.CreateToken(user),
					UserName = user.UserName,
					Image = null
				};
			}

			throw new Exception("Client creation failed");
		}
	}
}
