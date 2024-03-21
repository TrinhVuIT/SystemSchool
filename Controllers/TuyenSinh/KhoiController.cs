using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.HoSoTuyenSinhService;
using NS.Core.Business.KetQuaThiService;
using NS.Core.Business.KhoiService;
using NS.Core.Commons;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class KhoiController : ControllerBase
    {
        private readonly IKhoiService _khoiService;
        public KhoiController(IKhoiService khoiService)
        {
            _khoiService = khoiService;
        }
        [HttpGet]
        public async Task<ActionResult<List<KhoiReponseModel>>> GetListKhoiTuyenSinh()
        {
            var res= await _khoiService.GetListKhoiTuyenSinh();
            return Ok(res);
        }
    }
}
