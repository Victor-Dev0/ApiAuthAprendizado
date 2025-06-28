using ApiAuth.Data;
using ApiAuth.DTO.Usuario;
using ApiAuth.Models;
using ApiAuth.Repositorio.Interfaces;

namespace ApiAuth.Repositorio.Login
{
    public class LoginRepositorio : ILoginRepositorio
    {
        public async Task<Usuario> FazerLogin(UsuarioRequestDTO usuario)
        {
            var conexao = new SQLiteConexao();

            var consulta = @$"SELECT Email, Senha, Role 
                              FROM Usuarios 
                              WHERE Email = @Email";

            var retorno = await conexao.ExecutarConsulta<Usuario>(consulta);

            return retorno;
        }
    }
}
