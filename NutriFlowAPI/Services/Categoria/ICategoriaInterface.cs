using NutriFlowAPI.DTO.Categoria;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Categoria
{
    public interface ICategoriaInterface
    {
        Task<ResponseModel<List<CategoriaModel>>> ListarCategorias();
        Task<ResponseModel<CategoriaModel>> BuscarCategoriaPorId(int idCategoria);
        Task<ResponseModel<List<CategoriaModel>>> CriarCategoria(CategoriaCriacaoDTO categoriaCriacaoDTO);

        Task<ResponseModel<List<CategoriaModel>>> ExcluirCategoria(int idCategoria);
        Task<ResponseModel<List<CategoriaModel>>> EditarCategoria(CategoriaEdicaoDTO categoriaEdicaoDTO);
    }
}
