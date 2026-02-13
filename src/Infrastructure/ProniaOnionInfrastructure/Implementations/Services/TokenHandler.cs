using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;




namespace ProniaOnion.Infrastructure
{
    public class TokenHandler : ITokenHandler
    {
        public readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public TokenResponseDTO CreateToken(AppUser user, int minutes)
        {
            IEnumerable<Claim> userClaim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.GivenName,user.Name),
                new Claim(ClaimTypes.Surname,user.Surname),
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"])
            );

            SigningCredentials credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:audience"],
                expires: DateTime.Now.AddMinutes(30),
                notBefore: DateTime.Now,
                claims: userClaim,
                signingCredentials: credentials

            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(securityToken);

            return new TokenResponseDTO(token,user.UserName,securityToken.ValidTo);
        }
    }
}