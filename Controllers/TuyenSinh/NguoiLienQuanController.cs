using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.NguoiLienQuanServices;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class NguoiLienQuanController : ControllerBase
    {
        private readonly INguoiLienQuanServices _nguoiLienQuanServices;

        public NguoiLienQuanController(INguoiLienQuanServices nguoiLienQuanServices)
        {
            _nguoiLienQuanServices = nguoiLienQuanServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<NguoiLienQuanResponseModel>>> GetAll()
        {
            var res = _nguoiLienQuanServices.GetAll();
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<NguoiLienQuanResponseModel>> GetByHoSoTuyenSinhId([FromQuery] long hoSoTuyenSinhId)
        {
            var res = _nguoiLienQuanServices.GetByHoSoTuyenSinhId(hoSoTuyenSinhId);
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<NguoiLienQuanResponseModel>> GetById([FromQuery] long id)
        {
            var res = _nguoiLienQuanServices.GetById(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<NguoiLienQuanResponseModel>> AddNewNguoiLienQuan([FromQuery] Enums.LoaiQuanHe loaiQuanHe,[FromBody] NguoiLienQuanRequestModel nguoiLienQuan)
        {
            await  _nguoiLienQuanServices.AddNewNguoiLienQuan(loaiQuanHe,nguoiLienQuan);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<NguoiLienQuanResponseModel>> UpdateNguoiLienQuan([FromQuery] long id,[FromQuery] Enums.LoaiQuanHe loaiQuanHe ,[FromBody] NguoiLienQuanRequestModel nguoiLienQuan)
        {
            await _nguoiLienQuanServices.UpdateNguoiLienQuan(id,loaiQuanHe, nguoiLienQuan);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteNguoiLienQuan([FromQuery] long id)
        {
            await _nguoiLienQuanServices.DeleteNguoiLienQuan(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHoSoTuyenSinh()
        {
            var res =  _nguoiLienQuanServices.GetAllHoSoTuyenSinh();
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<NguoiLienQuanResponseModel>> GetHoSoTuyenSinhById([FromQuery] long id)
        {
            var res = _nguoiLienQuanServices.GetHoSoTuyenSinhById(id);
            return Ok(res);
        }
        
    }
}
