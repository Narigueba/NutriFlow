using NutriFlowAPI.DTO.Marca;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Marca
{
    public interface IMarcaInterface
    {
        Task<ResponseModel<List<MarcaModel>>> ListarMarcas();
        Task<ResponseModel<MarcaModel>> BuscarMarcaPorId(int idMarca);
        Task<ResponseModel<List<MarcaModel>>> CriarMarca(MarcaCriacaoDTO marcaCriacaoDTO);
        Task<ResponseModel<List<MarcaModel>>> EditarMarca(MarcaEdicaoDTO marcaEdicaoDTO);
        Task<ResponseModel<List<MarcaModel>>> ExcluirMarca(int idMarca);
    }
}
