using NutriFlowAPI.Models;
using NutriFlowAPI.Models.Usuario;
using NutriFlowAPI.DTO.Usuario;

namespace NutriFlowAPI.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario);
        Task<ResponseModel<List<UsuarioModel>>> CriarUsuario(UsuarioCriacaoDTO usuarioCriacaoDTO);
    }
}
