using ApiAuth.DTO.Usuario;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAuth.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(UsuarioRequestDTO usuario)
        {
            var chave = Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]!);

            var handler = new JwtSecurityTokenHandler();
                        
            var credencial = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GerarClaims(usuario),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credencial,
                Issuer = _configuration["JwtConfig:Issuer"],
                Audience = _configuration["JwtConfig:Audience"]
            };

            var token = handler.CreateToken(tokenDescriptor);
            var strToken = handler.WriteToken(token);

            return strToken;
        }

        private static ClaimsIdentity GerarClaims(UsuarioRequestDTO usuario)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, usuario.Email!));
            ci.AddClaim(new Claim(ClaimTypes.Role, usuario.Role!));

            return ci;
        }
    }
}
