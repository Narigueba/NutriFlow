using NutriFlowAPI.Models;
using NutriFlowAPI.Models.Usuario;

namespace NutriFlowAPI.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario);

    }
}
