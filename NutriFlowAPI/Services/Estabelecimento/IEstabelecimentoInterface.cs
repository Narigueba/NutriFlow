using NutriFlowAPI.DTO.Estabelecimento;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Estabelecimento
{
    public interface IEstabelecimentoInterface
    {
        Task<ResponseModel<List<CategoriaModel>>> ListarEstabelecimentos();
        Task<ResponseModel<CategoriaModel>> BuscarEstabelecimentoPorId(int idEstabelecimento);
        Task<ResponseModel<List<CategoriaModel>>> CriarEstabelecimento(EstabelecimentoCriacaoDTO estabelecimentoCriacaoDTO);
        Task<ResponseModel<List<CategoriaModel>>> ExcluirEstabelecimento(int idEstabelecimento);
        Task<ResponseModel<List<CategoriaModel>>> EditarEstabelecimento(EstabelecimentoEdicaoDTO estabelecimentoEdicaoDTO);
    }
}
