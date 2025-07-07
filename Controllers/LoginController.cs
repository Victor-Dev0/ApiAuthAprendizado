using ApiAuth.DTO.Usuario;
using ApiAuth.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(UsuarioRequestDTO usuario)
        {
            try
            {
                var response = await _loginService.Login(usuario);

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
