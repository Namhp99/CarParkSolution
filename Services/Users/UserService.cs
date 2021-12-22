using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.View.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        public UserService(IConfiguration config)
        {
            _config = config;
        }
        public string Login(LoginRequest request)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
