using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.ThoiGianThiService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ThoiGianThiController : ControllerBase
    {
        public readonly IThoiGianThiServices _thoiGianThiServices;

        public ThoiGianThiController(IThoiGianThiServices thoiGianThiServices)
        {
            _thoiGianThiServices = thoiGianThiServices;
        }

        [HttpPost]
        public async Task<ActionResult<ThoiGianThiResponseModel>> CreateThoiGianThi([FromBody] CreateThoiGianThiRequestModel input)
        {
            await _thoiGianThiServices.CreateThoiGianThi(input);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ThoiGianThiResponseModel>> UpdateThoiGianThi(long id, UpdateThoiGianThiRequestModel input)
        {
            await _thoiGianThiServices.UpdateThoiGianThi(id, input);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThoiGianThiResponseModel>> GetThoiGianThiById(long id)
        {
            var res = await _thoiGianThiServices.GetThoiGianThiById(id);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThoiGianThi(long id)
        {
            await _thoiGianThiServices.DeleteThoiGianThi(id);
            return Ok();
        }
       
        [HttpGet]
        public async Task<ActionResult<List<ThoiGianThiResponseModel>>> GetPagedThoiGianThi([FromQuery] GetPagedThoiGianThiRequestModel input)
        {
            var res = await _thoiGianThiServices.GetPagedThoiGianThi(input);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<List<ThoiGianThiResponseModel>>> GetPagedThoiGianThiByKyTuyenSinhId([FromQuery] GetPagedThoiGianThiByKyTuyenSinhIdRequestModel input)
        {
            var res = await _thoiGianThiServices.GetPagedThoiGianThiByKyTuyenSinhId(input);
            return Ok(res);
        }

    }
}
