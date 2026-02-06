using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KS.Scheduler.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KS.Scheduler.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool ValidarSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

        public string GerarToken(Guid usuarioId, string email, string nome)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var expiracao = int.Parse(_configuration["JwtSettings:ExpiracaoEmHoras"]);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, nome)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expiracao),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}