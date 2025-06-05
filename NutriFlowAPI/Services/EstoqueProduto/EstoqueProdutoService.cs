using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
using NutriFlowAPI.DTO.EstoqueProduto;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Services.EstoqueProduto
{
    public class EstoqueProdutoService : IEstoqueProdutoInterface
    {
        private readonly AppDbContext _context;
        public EstoqueProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<EstoqueProdutoModel>>> CriarEstoqueProduto(EstoqueProdutoCriacaoDTO estoqueProdutoCriacaoDTO)
        {
            ResponseModel<List<EstoqueProdutoModel>> resposta = new ResponseModel<List<EstoqueProdutoModel>>();

            try
            {
                // Verificar se os registros relacionados existem
                var usuario = await _context.Usuarios.FindAsync(estoqueProdutoCriacaoDTO.UsuarioId);
                var categoria = await _context.Categorias.FindAsync(estoqueProdutoCriacaoDTO.CategoriaId);
                var produto = await _context.Produtos.FindAsync(estoqueProdutoCriacaoDTO.ProdutoId);
                var marca = await _context.Marcas.FindAsync(estoqueProdutoCriacaoDTO.MarcaId);
                var unidade = await _context.UnidadeMedidas.FindAsync(estoqueProdutoCriacaoDTO.UnidadeMedidaId);
                var estabelecimento = await _context.Estabelecimentos.FindAsync(estoqueProdutoCriacaoDTO.EstabelecimentoId);

                if (usuario == null || categoria == null || produto == null || marca == null || unidade == null || estabelecimento == null)
                {
                    resposta.Mensagem = "Um ou mais IDs fornecidos não existem.";
                 
                    return resposta;
                }

                // Criar o objeto
                var novoEstoque = new EstoqueProdutoModel
                {
                    Usuario = usuario,
                    Categoria = categoria,
                    Produto = produto,
                    Marca = marca,
                    Quantidade = estoqueProdutoCriacaoDTO.Quantidade,
                    UnidadeMedida = unidade,
                    Preco = estoqueProdutoCriacaoDTO.Preco,
                    Estabelecimento = estabelecimento,
                    DataValidade = estoqueProdutoCriacaoDTO.DataValidade,
                    Descricao = estoqueProdutoCriacaoDTO.Descricao,
                    Ativo = estoqueProdutoCriacaoDTO.Ativo,
                    DataRegistro = DateTime.Now
                };

                // Adicionar ao banco
                _context.EstoqueProdutos.Add(novoEstoque);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.EstoqueProdutos.ToListAsync();
                resposta.Mensagem = "Produto de estoque criado com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro ao criar o produto: {ex.Message}";
                
                return resposta;
            }
        }

        public Task<ResponseModel<List<EstoqueProdutoModel>>> EditarEstoqueProduto(EstoqueProdutoEdicaoDTO estoqueProdutoEdicaoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<EstoqueProdutoModel>>> ExcluirEstoqueProduto(int idEstoqueProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<EstoqueProdutoModel>>> ListarEstoqueProduto()
        {
            ResponseModel<List<EstoqueProdutoModel>> resposta = new ResponseModel<List<EstoqueProdutoModel>>();

            try
            {
                var lista = await _context.EstoqueProdutos
                     .Include(e => e.Produto)
                     .Include(e => e.Categoria)
                     .Include(e => e.Marca)
                     .Include(e => e.Usuario)
                     .Include(e => e.Estabelecimento)
                     .Include(e => e.UnidadeMedida)
                     .ToListAsync();

                resposta.Dados = lista;
                resposta.Mensagem = "Estoque de produtos localizado com sucesos";

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
