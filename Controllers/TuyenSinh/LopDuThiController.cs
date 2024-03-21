using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.LopDuThiService;
using NS.Core.Business.ThanhVienHoiDongService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.LopDuThi;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LopDuThi;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE_WITHOUT_ACTION)]
    [ApiController]
    public class LopDuThiController : ControllerBase
    {
        private readonly ILopDuThiService _lopDuThiService;
        private readonly IThanhVienHoiDong _thanhVienHoiDongService;
        public LopDuThiController(ILopDuThiService lopDuThiService, IThanhVienHoiDong thanhVienHoiDongService)
        {
            _lopDuThiService = lopDuThiService;
            _thanhVienHoiDongService = thanhVienHoiDongService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LopDuThiResponseModel>> Get(long id)
        {
            var res = await _lopDuThiService.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAndUpdateLopDuThiRequestModel model)
        {
            await _lopDuThiService.AddChange(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CreateAndUpdateLopDuThiRequestModel model,long id)
        {
            await _lopDuThiService.AddChange(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _lopDuThiService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<LopDuThiResponseModel>>> GetAll([FromQuery] BasePaginationRequestModel model)
        {
            var res = await _lopDuThiService.GetAll(model);
            return Ok(res);
        }


        [HttpGet("GiaoVien")]
        public async Task<ActionResult<BasePaginationResponseModel<ThanhVienHoiDongForDropdownResponModel>>> GetAllGiaoVien([FromQuery] GetAllThanhVienHoiDongRequestModel model)
        {
            var res = await _lopDuThiService.GetAllThanhVienHoiDong(model);
            return Ok(res);
        }

        [HttpPost("GiaoVien")]
        public async Task<IActionResult> AddGiaoVien(AddGiaoVienToLopDuThiRequestModel model)
        {
            await _lopDuThiService.AddGiaoVien(model);
            return Ok();
        }
        [HttpDelete("GiaoVien/{id}")]
        public async Task<IActionResult> DeleteGiaoVien(long id)
        {
            await _lopDuThiService.DeleteGiaoVien(id);
            return Ok();
        }

    }
}
