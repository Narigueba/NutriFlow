using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriFlowAPI.DTO.UnidadeMedida;
using NutriFlowAPI.Models;
using NutriFlowAPI.Services.UnidadeMedida;

namespace NutriFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaInterface _unidadeMedidaInterface;
        public UnidadeMedidaController(IUnidadeMedidaInterface unidadeMedidaInterface)
        {
            _unidadeMedidaInterface = unidadeMedidaInterface;
        }

        [HttpGet("ListarUnidadesMedidas")]
        public async Task<ActionResult<ResponseModel<List<UnidadeMedidaModel>>>> ListarUnidadesMedidas()
        {
            var unidadesMedidas = await _unidadeMedidaInterface.ListarUnidadesMedidas();
            return Ok(unidadesMedidas);
        }

        [HttpGet("BuscarUnidadeMedidaPorId/{idUnidadeMedida}")]
        public async Task<ActionResult<ResponseModel<UnidadeMedidaModel>>> BuscarUnidadeMedidaPorId(int idUnidadeMedida)
        {
            var unidadeMedida = await _unidadeMedidaInterface.BuscarUnidadeMedidaPorId(idUnidadeMedida);
            return Ok(unidadeMedida);
        }

        [HttpPost("CriarUnidadeMedida")]
        public async Task<ActionResult<ResponseModel<List<UnidadeMedidaModel>>>> CriarUnidadeMedida(UnidadeMedidaCriacaoDTO unidadeMedidaCriacaoDTO)
        {
            var unidadesMedidas = await _unidadeMedidaInterface.CriarUnidadeMedida(unidadeMedidaCriacaoDTO);
            return Ok(unidadesMedidas);
        }

        [HttpDelete("ExcluirUnidadeMedida")]
        public async Task<ActionResult<ResponseModel<List<UnidadeMedidaModel>>>> ExcluirUnidadeMedida(int idUnidadeMedida)
        {
            var unidadesMedidas = await _unidadeMedidaInterface.ExcluirUnidadeMedida(idUnidadeMedida);
            return Ok(unidadesMedidas);
        }

        [HttpPut("EditarUnidadeMedida")]
        public async Task<ActionResult<ResponseModel<List<UnidadeMedidaModel>>>> EditarUnidadeMedida(UnidadeMedidaEdicaoDTO unidadeMedidaEdicaoDTO)
        {
            var unidadesMedidas = await _unidadeMedidaInterface.EditarUnidadeMedida(unidadeMedidaEdicaoDTO);
            return Ok(unidadesMedidas);
        }

    }
}
