using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


    }
}
