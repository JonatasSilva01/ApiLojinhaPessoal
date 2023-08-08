using Microsoft.IdentityModel.Tokens;
using PrimeiroInfluencer.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimeiroInfluencer.Services
{
    public class TokenServices
    {
        private IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenereteToken(User user)
        {

            Claim[] claims = new Claim[]
            {
                new Claim("userName", user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Id", user.Id),
                new Claim("loginTimesStamp", DateTime.UtcNow.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(expires: DateTime.Now.AddSeconds(86400), claims: claims, signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
