using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.HoiDongKhaoThiService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE_WITHOUT_ACTION)]
    [ApiController]
    public class HoiDongKhaoThiController : ControllerBase
    {
        private readonly IHoiDongKhaoThiService _hoiDongKhaoThiService;
        public HoiDongKhaoThiController(IHoiDongKhaoThiService hoiDongKhaoThiService)
        {
            _hoiDongKhaoThiService = hoiDongKhaoThiService;
        }

        [HttpPost]
        public IActionResult CreateHoiDongKhaoThi(CreateOrUpdateHoiDongKhaoThiModel data)
        {
            _hoiDongKhaoThiService.CreateHoiDongKhaoThi(data);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHoiDongKhaoThi(long id, CreateOrUpdateHoiDongKhaoThiModel data)
        {
            _hoiDongKhaoThiService.UpdateHoiDongKhaoThi(id, data);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHoiDongKhaoThi(long id)
        {
            _hoiDongKhaoThiService.DeleteHoiDongKhaoThi(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HoiDongKhaoThiResponseModel>> GetHoiDongKhaoThiById(long id)
        {
            var result = await _hoiDongKhaoThiService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<HoiDongKhaoThiResponseModel>>> GetPagedHDKT([FromQuery] BasePaginationRequestModel input)
        {
            var result = await _hoiDongKhaoThiService.GetPaged(input);
            return Ok(result);
        }
       
    }
}
