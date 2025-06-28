using ApiAuth.DTO.Usuario;
using ApiAuth.Repositorio.Interfaces;
using ApiAuth.Services.Interfaces;

namespace ApiAuth.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepositorio _loginRepositorio;
        private readonly TokenService _tokenService;
        public LoginService(ILoginRepositorio login, TokenService tokenService)
        {
            _loginRepositorio = login;
            _tokenService = tokenService;
        }
        public async Task<UsuarioResponseDTO> Login(UsuarioRequestDTO usuario)
        {
            var aux = await _loginRepositorio.FazerLogin(usuario) ?? throw new Exception("Usuario não foi encontrado");

            if (usuario.Senha != aux.Senha)
            {
                throw new Exception("Senha inválida!");
            }

            var token = _tokenService.GerarToken(aux);

            return new UsuarioResponseDTO { Email = aux.Email, Token = token };
        }
    }
}
