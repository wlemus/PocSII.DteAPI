using PocSII.DteAPIApplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.Services.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponse> Authenticate(UsuarioLoginRequest usuarioLoginRequest);
 
    }
}
