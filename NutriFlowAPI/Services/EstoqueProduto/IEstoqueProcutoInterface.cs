using NutriFlowAPI.DTO.EstoqueProduto;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.EstoqueProduto
{
    public interface IEstoqueProdutoInterface
    {
        Task<ResponseModel<List<EstoqueProdutoModel>>> CriarEstoqueProduto (EstoqueProdutoCriacaoDTO estoqueProdutoCriacaoDTO);
        Task<ResponseModel<List<EstoqueProdutoModel>>> ListarEstoqueProduto();
        Task<ResponseModel<List<EstoqueProdutoModel>>> ExcluirEstoqueProduto(int idEstoqueProduto);
        Task<ResponseModel<List<EstoqueProdutoModel>>> EditarEstoqueProduto(EstoqueProdutoEdicaoDTO estoqueProdutoEdicaoDTO);
    }
}
