using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriFlowAPI.DTO.EstoqueProduto;
using NutriFlowAPI.Models;
using NutriFlowAPI.Services.EstoqueProduto;
using System.Reflection.Metadata.Ecma335;

namespace NutriFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueProdutoController : ControllerBase
    {
        private readonly IEstoqueProdutoInterface _estoqueProdutoInterface;
        public EstoqueProdutoController(IEstoqueProdutoInterface estoqueProdutoInterface)
        {
            _estoqueProdutoInterface = estoqueProdutoInterface;
        }

        [HttpGet("ListarEstoqueProduto")]
        public async Task<ActionResult<ResponseModel<List<EstoqueProdutoDTO>>>> ListarEstoqueProduto()
        {
            var estoque = await _estoqueProdutoInterface.ListarEstoqueProduto();
            
            var dto = estoque.Dados.Select(e => new EstoqueProdutoDTO
            {
                UsuarioId = e.Usuario.Id,
                Usuario = e.Usuario.Nome, // ← aqui

                CategoriaId = e.Categoria.Id,
                Categoria = e.Categoria.Categoria, // ← aqui

                ProdutoId = e.Produto.Id,
                Produto = e.Produto.Produto, // ← aqui

                MarcaId = e.Marca.Id,
                Marca = e.Marca.Marca, // ← aqui

                Quantidade = e.Quantidade,

                UnidadeMedidaId = e.UnidadeMedida.Id,
                UnidadeMedida = e.UnidadeMedida.UnidadeMedida, // ← aqui

                Preco = e.Preco,

                EstabelecimentoId = e.Estabelecimento.Id,
                Estabelecimento = e.Estabelecimento.Estabelecimento, // ← aqui

                DataRegisto = e.DataRegistro,
                DataValidade = e.DataValidade,
                Descricao = e.Descricao,
                Ativo = e.Ativo,
            }).ToList();

            var response = new ResponseModel<List<EstoqueProdutoDTO>>
            {
                Mensagem = "Produtos encontrados",
                Dados = dto
            };

            return Ok(response);
        }

        
    }
}
