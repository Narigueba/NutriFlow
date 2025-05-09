using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Categoria
{
    public interface ICategoriaInterface
    {
        Task<ResponseModel<List<CategoriaModel>>> ListarCategorias();
        Task<ResponseModel<CategoriaModel>> BuscarCategoriaPorId(int idCategoria);
    }
}
