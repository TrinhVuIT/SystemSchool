using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.TieuChiDanhGiaService;
using NS.Core.Business.TieuChiMonThiService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TieuChiMonThiController : ControllerBase
    {
        private ITieuChiMonThiService _service;
        public TieuChiMonThiController(ITieuChiMonThiService tieuChiMonThiService)
        {
            _service = tieuChiMonThiService;
        }
            [HttpPost]
            public async Task<IActionResult> AddTieuChi([FromBody] AddOrUpdateTieuChiMonThiRequestModel newTieuChi)
            {
                await _service.AddTieuChiMonThi(newTieuChi);
                return Ok();

            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTieuChi(long id, [FromBody] AddOrUpdateTieuChiMonThiRequestModel updateTieuChi)
            {
                await _service.UpdateTieuChiMonThi(id, updateTieuChi);
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteTieuChi(long id)
            {
                _service.DeleteTieuChiMonThi(id);
                return Ok();
            }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<TieuChiMonThiResponseModel>>> GetAvailableAndPaging([FromQuery] BasePaginationRequestModel data)
        {
            var s = await _service.GetAvailableAndPaging(data);
            return Ok(s);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAvailable()
        //{
        //    return Ok(_service.GetAllAvailable());
        //}
        [HttpGet]
        public async Task<IActionResult> GetMonThiTuyenSinhAvailableForDropDown()
        {
            var result = await _service.GetMonThiTuyenSinhAvailableForDropDown();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetTieuChiDanhGiaAvailableForDropDown()
        {
            var result = await _service.GetTieuChiDanhGiaAvailableForDropDown();
            return Ok(result);
        }
    }
}

