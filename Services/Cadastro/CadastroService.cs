using ApiAuth.Models;
using ApiAuth.Repositorio.Interfaces;
using ApiAuth.Services.Interfaces;

namespace ApiAuth.Services.Cadastro
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepositorio _repositorio;
        public CadastroService(ICadastroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<string> CadastrarUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha) || string.IsNullOrEmpty(usuario.Role))
            {
                return "Todos os campos sao obrigatorios";
            }

            var aux = await _repositorio.Cadastrar(usuario);

            if (!aux)
            {
                throw new Exception("Erro ao cadastrar usuario");
            }

            return "Usuario cadastrado com sucesso!";
        }
    }
}
