using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.Categoria
{
    public class CategoriaService : ICategoriaInterface
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ResponseModel<CategoriaModel>> BuscarCategoriaPorId(int idCategoria)
        {
            ResponseModel<CategoriaModel> resposta = new ResponseModel<CategoriaModel>();

            try
            {
                var categoria = await _context.Categorias.
                    FirstOrDefaultAsync(categoriaBanco => categoriaBanco.Id == idCategoria);

                if (categoria == null)
                {
                    resposta.Mensagem = "Nenhuma registro localizado";
                    return resposta;
                }

                resposta.Dados = categoria;
                resposta.Mensagem = "Categoria localizada!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<CategoriaModel>>> ListarCategorias()
        {
            ResponseModel<List<CategoriaModel>> resposta = new ResponseModel<List<CategoriaModel>>();

            try
            {
                var categorias = await _context.Categorias.ToListAsync();
                
                resposta.Dados = categorias;
                resposta.Mensagem = "Todas as categorias foram coletadas";
                
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
