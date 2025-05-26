using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriFlowAPI.DTO.Categoria;
using NutriFlowAPI.DTO.Produto;
using NutriFlowAPI.Models;
using NutriFlowAPI.Services.Categoria;
using NutriFlowAPI.Services.Produto;

namespace NutriFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase

    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> CriarProduto([FromForm] ProdutoCriacaoDTO produtoCriacaoDTO)
        {
            var produtos = await _produtoInterface.CriarProduto(produtoCriacaoDTO);
            return Ok(produtos);
        }

        [HttpGet("ListarProdutos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListarProdutos()
        {
            var produtos = await _produtoInterface.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("BuscarProdutoPorId/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> BuscarProdutoPorId(int idProduto)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(idProduto);
            return Ok(produto);
        }

    }
}
