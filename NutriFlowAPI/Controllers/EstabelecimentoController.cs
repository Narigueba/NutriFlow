using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriFlowAPI.DTO.Estabelecimento;
using NutriFlowAPI.Models;
using NutriFlowAPI.Services.Estabelecimento;

namespace NutriFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoInterface _estabelecimentoInterface;

        public EstabelecimentoController(IEstabelecimentoInterface estabelecimentoInterface)
        {
            _estabelecimentoInterface = estabelecimentoInterface;
        }

        [HttpGet("ListarEstabelecimentos")]
        public async Task<ActionResult<ResponseModel<List<EstabelecimentoModel>>>> ListarEstabelecimentos()
        {
            var estabelecimentos = await _estabelecimentoInterface.ListarEstabelecimentos();
            return Ok(estabelecimentos);
        }

        [HttpGet("BuscarEstabelecimentoPorId/{idEstabelecimento}")]
        public async Task<ActionResult<ResponseModel<EstabelecimentoModel>>> BuscarEstabelecimentoPorId(int idEstabelecimento)
        {
            var estabelecimento = await _estabelecimentoInterface.BuscarEstabelecimentoPorId(idEstabelecimento);
            return Ok(estabelecimento);
        }

        [HttpPost("CriarEstabelecimento")]
        public async Task<ActionResult<ResponseModel<List<EstabelecimentoModel>>>> CriarEstabelecimento(EstabelecimentoCriacaoDTO estabelecimentoCriacaoDTO)
        {
            var estabelecimentos = await _estabelecimentoInterface.CriarEstabelecimento(estabelecimentoCriacaoDTO);
            return Ok(estabelecimentos);
        }

        [HttpPut("EditarEstabelecimento")]
        public async Task<ActionResult<ResponseModel<List<EstabelecimentoModel>>>> EditarEstabelecimento(EstabelecimentoEdicaoDTO estabelecimentoEdicaoDTO)
        {
            var estabelecimentos = await _estabelecimentoInterface.EditarEstabelecimento(estabelecimentoEdicaoDTO);
            return Ok(estabelecimentos);
        }

        [HttpDelete("ExcluirEstabelecimento")]
        public async Task<ActionResult<ResponseModel<List<EstabelecimentoModel>>>> ExcluirEstabelecimento(int idEstabelecimento)
        {
            var estabelecimentos = await _estabelecimentoInterface.ExcluirEstabelecimento(idEstabelecimento);
            return Ok(estabelecimentos);
        }
    }
}
