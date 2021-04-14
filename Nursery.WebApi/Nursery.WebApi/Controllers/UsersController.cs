using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nursery.Application.Account;
using Nursery.Application.Account.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursery.WebApi.Controllers
{
    //[AllowAnonymous]
    [Authorize]
    public class UsersController : BaseController
    {
        [HttpGet]
        [Route("profile")]
        public async Task<ActionResult<ProfileViewModel>> ProfileAsync()
        {
            var userName = User.Claims
                 .FirstOrDefault(x => x.Type == "username").Value;
            ProfileCommand query = new ProfileCommand
            {
                UserName = userName
            };
            return await Mediator.Send(query);
        }
    }
}
