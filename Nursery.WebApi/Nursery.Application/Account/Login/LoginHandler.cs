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

namespace Nursery.Application.Account.Login
{
	public class LoginHandler : IRequestHandler<LoginCommand, UserViewModel>
	{
		private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

		public LoginHandler(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
		{
			_userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
		}

		public async Task<UserViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new RestException(HttpStatusCode.Unauthorized);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                return new UserViewModel
                {
                    Token = _jwtGenerator.CreateToken(user)
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
	}
}
