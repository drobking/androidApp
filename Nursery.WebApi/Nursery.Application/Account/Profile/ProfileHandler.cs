using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

namespace Nursery.Application.Account.Profile
{
    public class ProfileHandler : IRequestHandler<ProfileCommand, ProfileViewModel>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IConfiguration _configuration;

        public ProfileHandler(UserManager<AppUser> userManager,
            IConfiguration configuration, 
            SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _configuration = configuration;
        }

        public async Task<ProfileViewModel> Handle(ProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new RestException(HttpStatusCode.NotFound);
            }
            string userImage = user.Image ?? "no-image.png";
            string image = "/" + _configuration.GetValue<string>("Folders:URLImages")+"/"+userImage;
            //if(user.Image)
            return new ProfileViewModel
            {
                Email = user.Email,
                Image = image
            };
        }
    }
}
