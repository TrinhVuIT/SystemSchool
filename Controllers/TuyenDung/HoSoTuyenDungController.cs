using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.HoSoTuyenDungService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class HoSoTuyenDungController : ControllerBase
    {
        private readonly IHoSoTuyenDungService _hoSoTuyenDungService;
        public HoSoTuyenDungController (IHoSoTuyenDungService hoSoTuyenDungService)
        {
            _hoSoTuyenDungService = hoSoTuyenDungService;
        }
        [HttpGet("{id}")]
        public IActionResult GetHoSoTuyenDung(long id)
        {
            var res = _hoSoTuyenDungService.GetHoSoTuyenDung(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddHoSoTuyenDung([FromBody] HoSoTuyenDungRequestModel hoSoTuyenDung)
        {
             await _hoSoTuyenDungService.AddHoSoTuyenDung(hoSoTuyenDung);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<HoSoTuyenDungResponseModel>>> GetListHoSoTuyenDung([FromQuery] BasePaginationRequestModel page)
        {
            var res = await _hoSoTuyenDungService.GetListHoSoTuyenDung(page);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateHoSoTuyenDung(long id,[FromBody]HoSoTuyenDungRequestModel data)
        {
            _hoSoTuyenDungService.UpdateHoSoTuyenDung(id, data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteHoSoTuyenDung(long id)
        {
            _hoSoTuyenDungService.DeleteHoSoTuyenDung(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStatusHoSoTuyenDung(long id, [FromQuery] TrangThaiHoSoTuyenDung trangthai)
        {
            await _hoSoTuyenDungService.UpdateStatus(id, trangthai);
            return Ok();
        }
    }
}
