using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.KetQuaThiService;
using NS.Core.Commons;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class KetQuaController : ControllerBase
    {
        private readonly IKetQuaService _ketQuaService;
        public KetQuaController(IKetQuaService ketQuaService)
        {
            _ketQuaService = ketQuaService;
        }

        [HttpPut]
        public async Task<ActionResult<IQueryable<KetQuaThiResponseModel>>> SubmitKetQuaThi(long hoSoThiId) {
            var res = await _ketQuaService.SubmitKetQuaThi(hoSoThiId);
            return Ok(res);
        }
    }
}
