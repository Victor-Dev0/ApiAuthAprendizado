using ApiAuth.Models;
using ApiAuth.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _service;
        public CadastroController(ICadastroService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarUsuarioNovo(Usuario usuario)
        {
            try
            {
                var retorno = await _service.CadastrarUsuario(usuario);

                if (retorno.Contains("Todos os campos sao obrigatorios"))
                {
                    return BadRequest(retorno);
                }

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
