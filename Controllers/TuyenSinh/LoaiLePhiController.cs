using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.BoPhanLienHeService;
using NS.Core.Business.LoaiLePhiService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class LoaiLePhiController : ControllerBase
    {
        private readonly ILoaiLePhiService _loaiLePhiServices;
        public LoaiLePhiController(ILoaiLePhiService loaiLePhiServices)
        {
            this._loaiLePhiServices = loaiLePhiServices;
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<LoaiLePhi>>> GetAllLoaiLePhi()
        {
            var result = await _loaiLePhiServices.GetAllLoaiLePhi();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAvailableLoaiLePhi()
        {
            var res = await _loaiLePhiServices.GetAvailableLoaiLePhi();
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<LoaiLePhi>>> GetPagedLoaiLePhi([FromQuery] GetPageLoaiLePhiRequestModel input)
        {
            var res = await _loaiLePhiServices.GetPagedLoaiLePhi(input);
            return Ok(res);
        }
        [HttpGet]
        public IQueryable<LoaiLePhi> GetLoaiLePhiById(long id)
        {
            return _loaiLePhiServices.GetLoaiLePhiById(id);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewLoaiLePhi([FromBody]LoaiLePhiRequestModel lePhi)
        {
            var res = await _loaiLePhiServices.AddNewLoaiLePhi(lePhi);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLoaiLePhi(long id, LoaiLePhiRequestModel lePhi)
        {
            var res = await _loaiLePhiServices.UpdateLoaiLePhi(id, lePhi);
            return Ok(res);
        }
        [HttpDelete]
        public void DeleteLoaiLePhi(long idloailephi)
        {
            _loaiLePhiServices.DeleteLoaiLePhi(idloailephi);
        }
    }
}
