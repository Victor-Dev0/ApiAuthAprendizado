using ApiAuth.Data;
using ApiAuth.Models;
using ApiAuth.Repositorio.Interfaces;

namespace ApiAuth.Repositorio.Cadastro
{
    public class CadastroRepositorio : ICadastroRepositorio
    {
        public async Task<bool> Cadastrar(Usuario usuario)
        {
            var conexao = new SQLiteConexao();

            var consulta = @"INSERT INTO Usuarios (Email, Senha, Role) VALUES (@Email, @Senha, @Role);";
            var consultaValidacao = @"SELECT Email, Senha, Role FROM Usuarios WHERE Email = @Email AND Senha = @Senha AND Role = @Role;";

            var retorno = await conexao.ExecutarConsulta<dynamic>(consulta, new { Email = usuario.Email, Senha = usuario.Senha, Role = usuario.Role });

            var retornoValidacao = await conexao.ExecutarConsulta<Usuario>(consultaValidacao, new { Email = usuario.Email, Senha = usuario.Senha, Role = usuario.Role });

            if (retornoValidacao != null)
            {
                return true;
            }
            return false;
        }
    }
}
