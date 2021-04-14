using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nursery.Application.Account;
using Nursery.Application.Account.Login;
using Nursery.Application.Account.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nursery.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserViewModel>> LoginAsync(LoginCommand query)
        {
            Thread.Sleep(5000);
            return await Mediator.Send(query);
        }
        [HttpPost("registration")]
        public async Task<ActionResult<UserViewModel>> RegistrationAsync(RegistrationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
