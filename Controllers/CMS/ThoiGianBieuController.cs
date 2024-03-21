using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.ThoiGianBieuService;
using NS.Core.Business.ThoiGianThiService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.ThoiGianBieuRequestModel;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.LandingPage;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ThoiGianBieuController : ControllerBase
    {
        public readonly IThoiGianBieuService _thoiGianBieuServices;

        public ThoiGianBieuController(IThoiGianBieuService thoiGianBieuServices)
        {
            _thoiGianBieuServices = thoiGianBieuServices;
        }


        // delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichSuKien(long id)
        {
            await _thoiGianBieuServices.DeleteLichSuKien(id);
            return Ok();
        }
        
       [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThoiGianBieu(long id)
        {
            await _thoiGianBieuServices.DeleteThoiGianBieu(id);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiSuKien(long id)
        {
            await _thoiGianBieuServices.DeleteLoaiSuKien(id);
            return Ok();
        }
        
        // get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaiSuKienById(long id)
        {
            var res = await _thoiGianBieuServices.GetLoaiSuKienById(id);
            return Ok(res);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLichSuKienById(long id)
        {
            var res = await _thoiGianBieuServices.GetLichSuKienById(id);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetThoiGianBieuById(long id)
        {
            var res = await _thoiGianBieuServices.GetThoiGianBieuById(id);
            return Ok(res);
        }

        // add change
        [HttpPut]
        public async Task<IActionResult> AddChangeThoiGianBieu([FromBody]CreateOrUpdateThoiGianBieuRequestModel data)
        {
            await _thoiGianBieuServices.AddChangeThoiGianBieu(data);
            return Ok();
        }    
        
        [HttpPut]
        public async Task<IActionResult> AddChangeLoaiSuKien([FromBody]CreateOrUpDateLoaiSuKienRequestModel data)
        {
            await _thoiGianBieuServices.AddChangeLoaiSuKien(data);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> AddChangeLichSuKien( [FromBody] CreateOrUpdateLichSuKienRequestModel data)
        {
            await _thoiGianBieuServices.AddChangeLichSuKien( data);
            return Ok();
        }
        
        // get all
        [HttpGet]
        public async Task<ActionResult<List<LoaiSuKienResponseModel>>> GetAllLoaiSuKien()
        {
            var res = await _thoiGianBieuServices.GetAllLoaiSuKien();
            return Ok(res);
        }
        
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<LichSuKienResponseModel>>> GetAllLichSuKien([FromQuery] LichSuKienRequestModel model)
        {
            var res = await _thoiGianBieuServices.GetAllLichSuKien(model);
            return Ok(res);
        }  
        
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<ThoiGianBieuResponseModel>>> GetAllThoiGianBieu([FromQuery] ThoiGianBieuRequestModel model)
        {
            var res = await _thoiGianBieuServices.GetAllThoiGianBieu(model);
            return Ok(res);
        }
    }
}
