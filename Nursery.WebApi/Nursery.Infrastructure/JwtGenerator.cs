using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nursery.Application.Interfaces;
using Nursery.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Nursery.Infrastructure
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;

        public JwtGenerator(UserManager<AppUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            roles = roles.OrderBy(x => x).ToList();
            //var image = user.Image;

            //if (image == null)
            //{
            //    image = _configuration.GetValue<string>("DefaultImage");
            //}


            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",user.Id.ToString()),
                new Claim("username",user.UserName),
                //new Claim("image",image)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }

            //var now = DateTime.UtcNow;
            //var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("JwtKey")));
            var signinCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signinCredentials,
                expires: DateTime.Now.AddDays(1000),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);

            //var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, user.UserName) };

            //var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.Now.AddDays(7),
            //    SigningCredentials = credentials
            //};
            //var tokenHandler = new JwtSecurityTokenHandler();

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            //return tokenHandler.WriteToken(token);
        }
    }
}
