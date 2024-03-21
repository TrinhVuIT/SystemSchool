using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.ThanhVienHoiDongService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE_WITHOUT_ACTION)]
    [ApiController]
    public class ThanhVienHoiDongController : ControllerBase
    {

        private readonly IThanhVienHoiDong _thanhVienHoiDongService;

        public ThanhVienHoiDongController(IThanhVienHoiDong thanhVienHoiDongService)
        {
            _thanhVienHoiDongService = thanhVienHoiDongService;
        }

        [HttpGet]
        [HttpGet(Constants.DefaultValue.DEFAULT_ACTION_ROUTE)]
        public async Task<ActionResult<BasePaginationResponseModel<ThanhVienHoiDongResponseModel>>> GetAll([FromQuery] ThanhVienHoiDongParams paramsModel)
        {
            BasePaginationResponseModel<ThanhVienHoiDongResponseModel> result = await _thanhVienHoiDongService.GetAllByHoiDongKhaoThiId(paramsModel);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        [HttpGet(Constants.DefaultValue.DEFAULT_ACTION_ROUTE+ "/{id}")]
        public async Task<ActionResult<BasePaginationResponseModel<ThanhVienHoiDongResponseModel>>> GetDetail(long id)
        {
            ThanhVienHoiDongResponseModel result = await _thanhVienHoiDongService.GetDetail(id);
            return Ok(result);
        }
        
        [HttpPost]
        [HttpPost(Constants.DefaultValue.DEFAULT_ACTION_ROUTE)]
        public async Task<IActionResult> Create([FromBody] CreateThanhVienHoiDongModel model)
        {
            await _thanhVienHoiDongService.Create(model);
            return Ok();
        }
        
        [HttpPut]
        [HttpPut(Constants.DefaultValue.DEFAULT_ACTION_ROUTE)]
        public async Task<IActionResult> Update(UpdateThanhVienHoiDongModel model)
        {
            await _thanhVienHoiDongService.Update(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [HttpDelete(Constants.DefaultValue.DEFAULT_ACTION_ROUTE+ "/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _thanhVienHoiDongService.Delete(id);
            return Ok();
        }

        [HttpGet(Constants.DefaultValue.DEFAULT_ACTION_ROUTE)]
        public async Task<ActionResult<List<HoiDongKhaoThiDropdownModel>>> GetHoiDongKhaoThiDropdown()
        {
            List<HoiDongKhaoThiDropdownModel> result = await _thanhVienHoiDongService.GetHoiDongKhaoThiDropdown();
            return Ok(result);
        }
     
    }
}
