using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using ReservationRestApi.Models;
using ReservationRestApi.ViewModel;

namespace ReservationRestApi.Services
{
    public class TokenService : ITokenService
    {

        public IConfiguration _config { get; }

        public TokenService (IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetToken(UserModel User)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return await Task.FromResult( new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
