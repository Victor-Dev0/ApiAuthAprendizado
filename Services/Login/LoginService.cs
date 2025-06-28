using ApiAuth.DTO.Usuario;
using ApiAuth.Services.Interfaces;

namespace ApiAuth.Services.Login
{
    public class LoginService : ILoginService
    {
        public Task<UsuarioResponseDTO> Login(UsuarioRequestDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
