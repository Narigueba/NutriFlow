using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriFlowAPI.DTO.Marca;
using NutriFlowAPI.Models;
using NutriFlowAPI.Services.Marca;

namespace NutriFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaInterface _marcaInterface;
        public MarcaController(IMarcaInterface marcaInterface)
        {
            _marcaInterface = marcaInterface; 
        }



        [HttpGet("ListarMarcas")]
        public async Task<ActionResult<ResponseModel<List<MarcaModel>>>> ListarMarcas()
        {
            var marcas = await _marcaInterface.ListarMarcas();
            return Ok(marcas);
        }

        [HttpGet("BuscarMarcaPorId")]
        public async Task<ActionResult<ResponseModel<MarcaModel>>> BuscarMarcaPorId(int idMarca)
        {
            var marca = await _marcaInterface.BuscarMarcaPorId(idMarca);
            return Ok(marca);
        }

        [HttpPost("CriarMarca")]
        public async Task<ActionResult<ResponseModel<MarcaModel>>> CriarMarca(MarcaCriacaoDTO marcaCriacaoDTO)
        {
            var marcas = await _marcaInterface.CriarMarca(marcaCriacaoDTO);
            return Ok(marcas);
        }

        [HttpPut("EditarMarca")]
        public async Task<ActionResult<ResponseModel<MarcaModel>>> EditarMarca(MarcaEdicaoDTO marcaEdicaoDTO)
        {
            var marcas = await _marcaInterface.EditarMarca(marcaEdicaoDTO);
            return Ok(marcas);
        }

        [HttpDelete("ExcluirMarca")]
        public async Task<ActionResult<ResponseModel<MarcaModel>>> ExcluirMarca(int idMarca)
        {
            var marcas = await _marcaInterface.ExcluirMarca(idMarca);
            return Ok(marcas);
        }

    }
}
