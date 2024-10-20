using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Services;
using atwork_CRUD_backend_Infraestructure.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace atwork_CRUD_backend_Infraestructure.Services
{

    public class TokenProviderService: ITokenProviderService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expirationInMinutes;

        public TokenProviderService(IOptions<JwtSettings> jwtSettings)
        {
            _secret = jwtSettings.Value.Secret;
            _issuer = jwtSettings.Value.Issuer;
            _audience = jwtSettings.Value.Audience;
            _expirationInMinutes = jwtSettings.Value.ExpirationInMinutes;
        }

        public string Create(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    ]),
                Expires = DateTime.UtcNow.AddMinutes(_expirationInMinutes),
                SigningCredentials = credentials,
                Issuer = _issuer,
                Audience = _audience
            };

            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);
            return token;
        }
    }
}
