using ApiAuth.DTO.Usuario;
using ApiAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public LoginController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("logar")]
        public async Task<ActionResult> Login(UsuarioRequestDTO usuario)
        {
            try
            {
                var token = _tokenService.GerarToken(usuario);
                var response = new UsuarioResponseDTO
                {
                    Email = usuario.Email,
                    Token = token
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("teste-auth")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> Autorização()
        {
            return Ok("Autorizado!!");

        }
    }
}
