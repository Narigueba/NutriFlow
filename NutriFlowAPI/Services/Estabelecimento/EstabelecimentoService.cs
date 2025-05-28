using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
using NutriFlowAPI.DTO.Estabelecimento;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Estabelecimento
{
    public class EstabelecimentoService : IEstabelecimentoInterface
    {
        private readonly AppDbContext _context;
        public EstabelecimentoService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<CategoriaModel>> BuscarEstabelecimentoPorId(int idEstabelecimento)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<EstabelecimentoModel>>> CriarEstabelecimento(EstabelecimentoCriacaoDTO estabelecimentoCriacaoDTO)
        {
            ResponseModel<List<EstabelecimentoModel>> resposta = new ResponseModel<List<EstabelecimentoModel>>();
            try
            {
                var estabelecimento = new EstabelecimentoModel()
                {
                    Estabelecimento = estabelecimentoCriacaoDTO.Estabelecimento,
                    Endereco = estabelecimentoCriacaoDTO.Endereco,
                    Ativo = estabelecimentoCriacaoDTO.Ativo,
                };

                _context.Add(estabelecimento);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estabelecimentos.ToListAsync();
                resposta.Mensagem = "Estabelecimento criado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public Task<ResponseModel<List<CategoriaModel>>> EditarEstabelecimento(EstabelecimentoEdicaoDTO estabelecimentoEdicaoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CategoriaModel>>> ExcluirEstabelecimento(int idEstabelecimento)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CategoriaModel>>> ListarEstabelecimentos()
        {
            throw new NotImplementedException();
        }
    }
}
