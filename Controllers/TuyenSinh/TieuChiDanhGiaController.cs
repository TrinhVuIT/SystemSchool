using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.TieuChiDanhGiaService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TieuChiDanhGiaController : ControllerBase
    {
        private readonly ITieuChiDanhGiaService _service;
        public TieuChiDanhGiaController(ITieuChiDanhGiaService tieuChiService)
        {
            _service = tieuChiService;
        }
        [HttpPost]
        public async Task<IActionResult> AddTieuChi([FromBody] AddOrUpdateTieuChiDanhGiaRequestModel newTieuChi)
        {
            await _service.AddTieuChiDanhGia(newTieuChi);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTieuChi(long id, [FromBody] AddOrUpdateTieuChiDanhGiaRequestModel updateTieuChi)
        {
            await _service.UpdateTieuChiDanhGia(id, updateTieuChi);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTieuChi(long id)
        {
            _service.DeleteTieuChiDanhGia(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<TieuChiDanhGiaResponseModel>>> GetAvailableAndPaging([FromQuery] BasePaginationRequestModel data)
        {
            var s = await _service.GetAvailableAndPaging(data);
            return Ok(s);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }
    }
}
