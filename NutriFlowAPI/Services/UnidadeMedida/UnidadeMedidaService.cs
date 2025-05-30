using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
using NutriFlowAPI.DTO.UnidadeMedida;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.UnidadeMedida
{
    public class UnidadeMedidaService : IUnidadeMedidaInterface
    {
        private readonly AppDbContext _context;
        public UnidadeMedidaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<UnidadeMedidaModel>> BuscarUnidadeMedidaPorId(int idUnidadeMedida)
        {
            ResponseModel<UnidadeMedidaModel> resposta = new ResponseModel<UnidadeMedidaModel>();
            try
            {
                var unidadeMedida = await _context.UnidadeMedidas
                    .FirstOrDefaultAsync(unidadeMedidaBanco => unidadeMedidaBanco.Id == idUnidadeMedida);

                if (unidadeMedida == null) 
                {
                    resposta.Mensagem = "Nenhum registro foi localizado";

                    return resposta;
                }

                resposta.Dados = unidadeMedida;
                resposta.Mensagem = "Unidade de Medida localizada com sucesso";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<UnidadeMedidaModel>>> CriarUnidadeMedida(UnidadeMedidaCriacaoDTO unidadeMedidaCriacaoDTO)
        {
            ResponseModel<List<UnidadeMedidaModel>> resposta = new ResponseModel<List<UnidadeMedidaModel>>();
            try
            {

                var unidadeMedida = new UnidadeMedidaModel()
                {
                    UnidadeMedida = unidadeMedidaCriacaoDTO.UnidadeMedida,
                    Sigla = unidadeMedidaCriacaoDTO.Sigla
                };

                _context.Add(unidadeMedida);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.UnidadeMedidas.ToListAsync();
                resposta.Mensagem = "Unidade Medida criada com sucesso";

                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<UnidadeMedidaModel>>> EditarUnidadeMedida(UnidadeMedidaEdicaoDTO unidadeMedidaEdicaoDTO)
        {
            ResponseModel<List<UnidadeMedidaModel>> resposta = new ResponseModel<List<UnidadeMedidaModel>>();
            try
            {
                var unidadeMedida = await _context.UnidadeMedidas
                    .FirstOrDefaultAsync(unidadeMedidaBanco => unidadeMedidaBanco.Id == unidadeMedidaEdicaoDTO.Id);

                if (unidadeMedida == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                unidadeMedida.UnidadeMedida = unidadeMedidaEdicaoDTO.UnidadeMedida;
                unidadeMedida.Sigla = unidadeMedidaEdicaoDTO.Sigla;

                _context.Update(unidadeMedida);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.UnidadeMedidas.ToListAsync();
                resposta.Mensagem = "Unidade Medida editada com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<UnidadeMedidaModel>>> ExcluirUnidadeMedida(int idUnidadeMedida)
        {
            ResponseModel<List<UnidadeMedidaModel>> resposta = new ResponseModel<List<UnidadeMedidaModel>>();
            try
            {
                var unidadeMedida = await _context.UnidadeMedidas
                    .FirstOrDefaultAsync(unidadeMedidaBanco => unidadeMedidaBanco.Id == idUnidadeMedida);

                if (unidadeMedida == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                _context.Remove(unidadeMedida);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.UnidadeMedidas.ToListAsync();
                resposta.Mensagem = "Unidade Medida excluida com sucesso";

                return resposta;


            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<UnidadeMedidaModel>>> ListarUnidadesMedidas()
        {
            ResponseModel<List<UnidadeMedidaModel>> resposta = new ResponseModel<List<UnidadeMedidaModel>>();
            try
            {
                var unidadesMedidas = await _context.UnidadeMedidas.ToListAsync();

                resposta.Dados = unidadesMedidas;
                resposta.Mensagem = "Todas as Unidades de Medidas foram coletadas";

                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
