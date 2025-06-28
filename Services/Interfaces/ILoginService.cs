using ApiAuth.DTO.Usuario;

namespace ApiAuth.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UsuarioResponseDTO> Login(UsuarioRequestDTO usuario);
    }
}
