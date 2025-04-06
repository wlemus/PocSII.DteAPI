using Microsoft.AspNetCore.Mvc;
using PocSII.DteAPIApplicacion.Common;
using PocSII.DteAPIApplicacion.DTOs;
using PocSII.DteAPIApplicacion.Interfaces;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocSII.DteAPI.Controllers.Auth
{
    [Route("api/v1/aut/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;
        public LoginController(ILogger<LoginController> logger, IUserService userService) {
          _logger = logger;
          _userService = userService;
        }
        // GET: api/Login
        [HttpPost]
        /// <summary>
        /// Autentica a un usuario y retorna un token JWT.
        /// </summary>
        /// <param name="request">Credenciales del usuario</param>
        /// <returns>Token de autenticación JWT</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MensajeError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MensajeError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginRequest request) {
          

                if (string.IsNullOrWhiteSpace(request.Usuario) || string.IsNullOrWhiteSpace(request.Clave)) {
                return BadRequest(new MensajeError {
                    Error = "Parámetros requeridos",
                  Detalle = "Debe enviar usuario y clave"
                });
              
            }

            if (string.IsNullOrWhiteSpace(request.Usuario) || string.IsNullOrWhiteSpace(request.Clave)) {
                return NotFound(new MensajeError {
                    Error = "Usuario no encontrado",
                    Detalle = "El usuario no existe en nuestro sistema"
                });

            }

            if (request.Usuario == "admin" && request.Clave == "1234") {
               var respuesta = await _userService.Authenticate(request);
                return Ok(respuesta);
            }

            return Unauthorized(new MensajeError {
                Error = "Credenciales inválidas",
                Detalle = "El usuario o la contraseña no son válidos"
            });

        }

    }
}
