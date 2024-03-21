using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.QuyDoiDiemService;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Commons;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class QuyDoiDiemController : ControllerBase
    {
        private readonly IQuyDoiDiemService _service;
        public QuyDoiDiemController(IQuyDoiDiemService quyDoiDiemService)
        {
            _service = quyDoiDiemService;
        }
        [HttpPost]
        public async Task<IActionResult> AddQuyDoiDIem([FromBody] AddOrUpdateQuyDoiDiemRequestModel newQuyDoiDiem)
        {
            await _service.AddQuyDoiDiem(newQuyDoiDiem);
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuyDoiDiem(long id, [FromBody] AddOrUpdateQuyDoiDiemRequestModel updateQuyDoiDiem)
        {
            await _service.UpdateQuyDoiDiem(id, updateQuyDoiDiem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuyDoiDiem(long id)
        {
            _service.DeleteQuyDoiDiem(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<QuyDoiDiemResponseModel>>> GetAvailabeAndPaging([FromQuery] BasePaginationRequestModel data)
        {
            var s = await _service.GetAvailableAndPaging(data);
            return Ok(s);
        }
        [HttpGet]
        public IActionResult GetById(long id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetMonThiTuyenSinhAvailableForDropDown()
        {
            var result = await _service.GetMonThiTuyenSinhAvailableForDropDown();
            return Ok(result);
        }
    }
}
