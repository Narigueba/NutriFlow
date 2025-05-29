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

        public async Task<ResponseModel<EstabelecimentoModel>> BuscarEstabelecimentoPorId(int idEstabelecimento)
        {
            ResponseModel<EstabelecimentoModel> resposta = new ResponseModel<EstabelecimentoModel>();

            try
            {
                var estabelecimento = await _context.Estabelecimentos
                    .FirstOrDefaultAsync(estabelecimentoBanco => estabelecimentoBanco.Id == idEstabelecimento);

                if (estabelecimento == null) 
                {
                    resposta.Mensagem = "Nenhum registro foi localizado";

                    return resposta;
                }

                resposta.Dados = estabelecimento;
                resposta.Mensagem = "Estabelecimento localizado";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
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
                    Ativo = estabelecimentoCriacaoDTO.Ativo
                };

                _context.Add(estabelecimento);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estabelecimentos.ToListAsync();
                resposta.Mensagem = "Estabelecimento criado com sucesso";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<EstabelecimentoModel>>> EditarEstabelecimento(EstabelecimentoEdicaoDTO estabelecimentoEdicaoDTO)
        {
            ResponseModel<List<EstabelecimentoModel>> resposta = new ResponseModel<List<EstabelecimentoModel>>();

            try
            {
                var estabelecimento = await _context.Estabelecimentos
                    .FirstOrDefaultAsync(estabelecimentoBanco => estabelecimentoBanco.Id == estabelecimentoEdicaoDTO.Id);

                if (estabelecimento == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                estabelecimento.Estabelecimento = estabelecimentoEdicaoDTO.Estabelecimento;
                estabelecimento.Endereco = estabelecimentoEdicaoDTO.Endereco;
                estabelecimento.Ativo = estabelecimentoEdicaoDTO.Ativo;

                _context.Update(estabelecimento);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estabelecimentos.ToListAsync();
                resposta.Mensagem = "Estabelecimento editado com sucesso";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<EstabelecimentoModel>>> ExcluirEstabelecimento(int idEstabelecimento)
        {
            ResponseModel<List<EstabelecimentoModel>> resposta = new ResponseModel<List<EstabelecimentoModel>>();

            try
            {
                var estabelecimento = await _context.Estabelecimentos
                    .FirstOrDefaultAsync(estabelecimentoBanco => estabelecimentoBanco.Id == idEstabelecimento);

                if (estabelecimento == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                _context.Remove(estabelecimento);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estabelecimentos.ToListAsync();
                resposta.Mensagem = "Estabelecimento removido com sucesso";
                
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<List<EstabelecimentoModel>>> ListarEstabelecimentos()
        {
            ResponseModel<List<EstabelecimentoModel>> resposta = new ResponseModel<List<EstabelecimentoModel>>();


            try
            {
                var estabelecimentos = await _context.Estabelecimentos.ToListAsync();

                resposta.Dados = estabelecimentos;
                resposta.Mensagem = "Todos os estabelecimentos foram coletados";

                return resposta;


            } catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
