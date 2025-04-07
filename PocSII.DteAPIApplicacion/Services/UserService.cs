using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using PocSII.DteAPIApplicacion.Common;
using PocSII.DteAPIApplicacion.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using PocSII.DteAPIApplicacion.Services.Interfaces;

namespace PocSII.DteAPIApplicacion.Services
{
   public class UserService: IUserService {

        private readonly AppSettings _appSettings;
        public UserService(IConfiguration configuration) {
            _appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
        }
        public async Task<TokenResponse> Authenticate(UsuarioLoginRequest usuarioLoginRequest) {
            // Implementación del método Authenticate
            return new TokenResponse { Token = GetToken(usuarioLoginRequest) };

        }

        private string GetToken(UsuarioLoginRequest usuarioLoginRequest) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, usuarioLoginRequest.Usuario)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

    }
}
