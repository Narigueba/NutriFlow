using NutriFlowAPI.DTO.UnidadeMedida;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.UnidadeMedida
{
    public interface IUnidadeMedidaInterface
    {
        Task<ResponseModel<List<UnidadeMedidaModel>>> ListarUnidadesMedidas();
        Task<ResponseModel<UnidadeMedidaModel>> BuscarUnidadeMedidaPorId(int idUnidadeMedida);
        Task<ResponseModel<List<UnidadeMedidaModel>>> CriarUnidadeMedida(UnidadeMedidaCriacaoDTO unidadeMedidaCriacaoDTO);
        Task<ResponseModel<List<UnidadeMedidaModel>>> EditarUnidadeMedida(UnidadeMedidaEdicaoDTO unidadeMedidaEdicaoDTO);
        Task<ResponseModel<List<UnidadeMedidaModel>>> ExcluirUnidadeMedida(int idUnidadeMedida);
    }
}
