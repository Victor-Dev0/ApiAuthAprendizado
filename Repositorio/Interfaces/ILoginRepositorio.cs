using ApiAuth.DTO.Usuario;
using ApiAuth.Models;

namespace ApiAuth.Repositorio.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<Usuario> FazerLogin(UsuarioRequestDTO usuario);
    }
}
