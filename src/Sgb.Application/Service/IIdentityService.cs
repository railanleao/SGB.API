using Sgb.Application.DTOs.Request;
using Sgb.Application.DTOs.Response;

namespace Sgb.Application.Service
{
    public interface IIdentityService
    {
        Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);
        Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId);
    }
}
 