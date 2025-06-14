using ApiAuth.Models;
using ApiAuth.Services;
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
        public async Task<ActionResult> Login(Usuario usuario)
        {
            try
            {
                var token = _tokenService.GerarToken(usuario);

                return Ok(new { UsuarioLogado = usuario, Token = token });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
