using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriFlowAPI.DTO.Categoria;
using NutriFlowAPI.Models;
using NutriFlowAPI.Services.Categoria;

namespace NutriFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaInterface _categoriaInterface;
        public CategoriaController(ICategoriaInterface categoriaInterface)
        {
            _categoriaInterface = categoriaInterface;
        }

        [HttpGet("ListarCategorias")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> ListarCategorias()
        {
            var categorias = await _categoriaInterface.ListarCategorias();
            return Ok(categorias);
        }

        [HttpGet("BuscarCategoriaPorId/{idCategoria}")]
        public async Task<ActionResult<ResponseModel<CategoriaModel>>> BuscarCategoriaPorId(int idCategoria)

        {
            var categoria = await _categoriaInterface.BuscarCategoriaPorId(idCategoria);
            return Ok(categoria);
        }

        [HttpPost("CriarCategoria")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> CriarCategoria(CategoriaCriacaoDTO categoriaCriacaoDTO)
        {
            var categorias = await _categoriaInterface.CriarCategoria(categoriaCriacaoDTO);
            return Ok(categorias); 
        }

        [HttpPut("EditarCategoria")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> EditarCategoria(CategoriaEdicaoDTO categoriaEdicaoDTO)
        {
            var categorias = await _categoriaInterface.EditarCategoria(categoriaEdicaoDTO);
            return Ok(categorias);
        }

        [HttpDelete("ExcluirCategoria")]
        public async Task<ActionResult<ResponseModel<CategoriaModel>>> ExcluirCategoria(int idCategoria)
        {
            var categorias = await _categoriaInterface.ExcluirCategoria(idCategoria);
            return Ok(categorias);
        }
    }

}
