using NutriFlowAPI.DTO.Produto;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<ProdutoModel>>> CriarProduto(ProdutoCriacaoDTO produtoCriacaoDTO);
        Task<ResponseModel<List<ProdutoModel>>> ListarProdutos();
        Task<ResponseModel<List<ProdutoModel>>> EditarProduto(ProdutoEdicaoDTO produtoEdicaoDTO);
        Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto);
        Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto);
    }
}
