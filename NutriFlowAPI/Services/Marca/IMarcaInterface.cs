using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Marca
{
    public interface IMarcaInterface
    {
        Task<ResponseModel<List<MarcaModel>>> ListarMarcas();
        Task<ResponseModel<MarcaModel>> BuscarMarcaPorId(int idMarca);
        
    }
}
