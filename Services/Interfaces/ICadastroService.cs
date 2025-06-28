using ApiAuth.Models;

namespace ApiAuth.Services.Interfaces
{
    public interface ICadastroService
    {
        Task<string> CadastrarUsuario(Usuario usuario);
    }
}
