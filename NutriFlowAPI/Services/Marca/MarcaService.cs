using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
using NutriFlowAPI.DTO.Marca;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Marca
{
    public class MarcaService : IMarcaInterface
    {
        private readonly AppDbContext _context;
        public MarcaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<MarcaModel>> BuscarMarcaPorId(int idMarca)
        {
            ResponseModel<MarcaModel> resposta = new ResponseModel<MarcaModel>();

            try
            {
                var marca = await _context.Marcas.FirstOrDefaultAsync(marcaBanco => marcaBanco.Id == idMarca);

                if (marca == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                resposta.Dados = marca;
                resposta.Mensagem = "Marca localizada";

                return resposta;
                


            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public Task<ResponseModel<List<MarcaModel>>> CriarMarca(MarcaCriacaoDTO marcaCriacaoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<MarcaModel>>> ListarMarcas()
        {
            ResponseModel<List<MarcaModel>> resposta = new ResponseModel<List<MarcaModel>>();
            
            try
            {
                var marcas = await _context.Marcas.ToListAsync();

                resposta.Dados = marcas;
                resposta.Mensagem = "Todas as marcas foram coletadas!";

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
