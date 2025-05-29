using NutriFlowAPI.DTO.Estabelecimento;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Estabelecimento
{
    public interface IEstabelecimentoInterface
    {
        Task<ResponseModel<List<EstabelecimentoModel>>> ListarEstabelecimentos();
        Task<ResponseModel<EstabelecimentoModel>> BuscarEstabelecimentoPorId(int idEstabelecimento);
        Task<ResponseModel<List<EstabelecimentoModel>>> CriarEstabelecimento(EstabelecimentoCriacaoDTO estabelecimentoCriacaoDTO);
        Task<ResponseModel<List<EstabelecimentoModel>>> ExcluirEstabelecimento(int idEstabelecimento);
        Task<ResponseModel<List<EstabelecimentoModel>>> EditarEstabelecimento(EstabelecimentoEdicaoDTO estabelecimentoEdicaoDTO);
    }
}
