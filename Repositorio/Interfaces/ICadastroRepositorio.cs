using ApiAuth.Models;

namespace ApiAuth.Repositorio.Interfaces
{
    public interface ICadastroRepositorio
    {
        Task<bool> Cadastrar(Usuario usuario);
    }
}
