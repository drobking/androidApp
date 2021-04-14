using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursery.Application.Account.Profile
{
    public class ProfileCommand : IRequest<ProfileViewModel>
    {
        public string UserName { get; set; }
    }

}
