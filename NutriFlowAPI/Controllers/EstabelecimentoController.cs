using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("CriarEstabelecimento")]

    }
}
