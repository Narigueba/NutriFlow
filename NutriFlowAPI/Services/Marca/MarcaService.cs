using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
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

        public Task<ResponseModel<MarcaModel>> BuscarMarcaPorId(int idMarca)
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
