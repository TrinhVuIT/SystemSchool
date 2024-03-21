using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.HoSoThiService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{

    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class HoSoThiController : ControllerBase
    {
        private readonly IHoSoThiService _hoSoThiService;
        public HoSoThiController(IHoSoThiService hoSoThiService)
        {
            _hoSoThiService = hoSoThiService;
        }
        
        [HttpGet("{thanhVienHDId}")]
        public async Task<ActionResult<List<HoSoThiResponseModel>>> GetHoSoThi(long thanhVienHDId) {
            var res = await _hoSoThiService.GetHoSoThi(thanhVienHDId);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasePaginationResponseModel<HoSoThiResponseModel>>> GetPageHoSoThi([FromQuery] GetPageHoSoThiRequestModel input, long id)
        {
            var res = await _hoSoThiService.GetPageHoSoThi(input, id);
            return Ok(res);
        }
        
        [HttpGet]
        public async Task<ActionResult<IQueryable<MonThiTuyenSinhResponseModel>>> GetDiemMonThiTuyenSinh([FromQuery] long hoSoId)
        {
            var res = await _hoSoThiService.GetDiemMonThiTuyenSinh(hoSoId);
            return Ok(res);
        }


        [HttpPut("{hoSoId}")]
        public async Task<IActionResult> UpdateTrangThaiHoSo(long hoSoId,long thanhVienHdId, [FromBody] UpdateTrangThaiHoSoThiRequestModel input)
        {
            var res = await _hoSoThiService.UpdateTrangThaiDuThi( hoSoId, thanhVienHdId,(int)input.Status);
            return Ok(res);
        }

        
    }
}
