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

        public async Task<ResponseModel<EstoqueProdutoModel>> BuscarEstoquePorId(int idEstoqueProduto)
        {
            ResponseModel<EstoqueProdutoModel> resposta = new ResponseModel<EstoqueProdutoModel>();

            try
            {
                var estoque = await _context.EstoqueProdutos
                            .Include(e => e.Produto)
                            .Include(e => e.Categoria)
                            .Include(e => e.Marca)
                            .Include(e => e.Usuario)
                            .Include(e => e.Estabelecimento)
                            .Include(e => e.UnidadeMedida)
                            .FirstOrDefaultAsync(e => e.Id == idEstoqueProduto);

                if (estoque == null)
                {
                    resposta.Mensagem = "Estoque não encontrado.";
                    return resposta;
                }

                resposta.Dados = estoque;
                resposta.Mensagem = "Estoque localizado com sucesso.";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<EstoqueProdutoModel>> CriarEstoqueProduto(EstoqueProdutoCriacaoDTO dto)
        {
            var resposta = new ResponseModel<EstoqueProdutoModel>();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(dto.UsuarioId);
                var produto = await _context.Produtos.FindAsync(dto.ProdutoId);
                var categoria = await _context.Categorias.FindAsync(dto.CategoriaId);
                var marca = await _context.Marcas.FindAsync(dto.MarcaId);
                var unidade = await _context.UnidadeMedidas.FindAsync(dto.UnidadeMedidaId);
                var estabelecimento = await _context.Estabelecimentos.FindAsync(dto.EstabelecimentoId);

                if (usuario == null || produto == null || categoria == null || marca == null || unidade == null || estabelecimento == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Um ou mais IDs são inválidos.";
                    return resposta;
                }

                var novoEstoque = new EstoqueProdutoModel
                {
                    Usuario = usuario,
                    Produto = produto,
                    Categoria = categoria,
                    Marca = marca,
                    Quantidade = dto.Quantidade,
                    UnidadeMedida = unidade,
                    Preco = dto.Preco,
                    Estabelecimento = estabelecimento,
                    DataValidade = dto.DataValidade,
                    Descricao = dto.Descricao,
                    Ativo = dto.Ativo,
                    DataRegistro = DateTime.Now
                };

                _context.EstoqueProdutos.Add(novoEstoque);
                await _context.SaveChangesAsync();

                resposta.Status = true;
                resposta.Mensagem = "Produto adicionado ao estoque com sucesso.";
                resposta.Dados = novoEstoque;
                

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro: {ex.Message}";
                return resposta;
            }
        }

        public Task<ResponseModel<List<EstoqueProdutoModel>>> EditarEstoqueProduto(EstoqueProdutoEdicaoDTO estoqueProdutoEdicaoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<EstoqueProdutoModel>>> ExcluirEstoqueProduto(int idEstoqueProduto)
        {
            ResponseModel<List<EstoqueProdutoModel>> resposta = new ResponseModel<List<EstoqueProdutoModel>>();

            try
            {
                var estoque = await _context.EstoqueProdutos
                              .FirstOrDefaultAsync(estoqueProdutoBanco => estoqueProdutoBanco.Id == idEstoqueProduto);

                if (estoque == null)
                {
                    resposta.Mensagem = "Produto não encontrado no estoque.";

                    return resposta;
                }

                _context.Remove(estoque);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.EstoqueProdutos.ToListAsync();
                resposta.Mensagem = "Produto removido do estoque com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
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
