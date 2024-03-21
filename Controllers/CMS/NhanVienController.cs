using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.NhanVienService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.NhanVien;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels.NhanVien;
using static NS.Core.Commons.Enums;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;
        public NhanVienController (INhanVienService giaoVienNhanVienService)
        {
            _nhanVienService = giaoVienNhanVienService;
        }
        
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateOrUpdate([FromForm] CreateOrUpdateNhanVienRequestModel model)
        {
            await _nhanVienService.CreateOrUpdate(model);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPagedNhanVien([FromQuery] GetPagedNhanVienRequestModel input)
        {
            var result = await _nhanVienService.GetPagedNhanVien(input);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetPagedNhanVienActive([FromQuery] GetPagedNhanVienRequestModel input)
        {
            var result = await _nhanVienService.GetPagedNhanVienActive(input);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAvailable()
        {
            var result = await _nhanVienService.GetAllAvailable();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDisplay()
        {
            var result = await _nhanVienService.GetAllDisplay();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            var result = await _nhanVienService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _nhanVienService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NhanVienRequestModel model)
        {
            await _nhanVienService.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] long id, [FromBody] NhanVienRequestModel model)
        {
            await _nhanVienService.Update(id, model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] long id) 
        {
            await _nhanVienService.Delete(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<NhanVienResponseModel>>> GetChuyenVienTamLy(bool isDisplay = false)
        {
            var result = await _nhanVienService.GetChuyenVienTamLy(isDisplay);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<NhanVienResponseModel>>> GetNhanVienByPhongBan(long id)
        {
            var result = await _nhanVienService.GetNhanVienByPhongBan(id);
            return Ok(result);
        }
        [HttpGet("{loaiPhongBan}")]
        public async Task<ActionResult<List<NhanVienResponseModel>>> GetNhanVienByLoaiPhongBan(LoaiPhongBan loaiPhongBan)
        {
            var result = await _nhanVienService.GetNhanVienByLoaiPhongBan(loaiPhongBan);
            return Ok(result);
        }
        [HttpGet("{loaiPhongBan}")]
        public async Task<ActionResult<List<NhanVienResponseModel>>> GetNhanVienByLoaiPhongBanActive(LoaiPhongBan loaiPhongBan)
        {
            var result = await _nhanVienService.GetNhanVienByLoaiPhongBanActive(loaiPhongBan);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChuyenVienTamLy(long id)
        {
             await _nhanVienService.UpdateLaChuyenVienTamLy(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHienThiNhanVien(long id)
        {
            await _nhanVienService.UpdateNhanVienActive(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHangCotNhanVien([FromBody]ChangeHangVaCotNhanVienRequestModel data)
        {
            await _nhanVienService.UpdateHangVaCot(data);
            return Ok();
        }
    }
}
