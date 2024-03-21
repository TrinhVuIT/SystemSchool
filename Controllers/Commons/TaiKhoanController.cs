using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.TaiKhoanService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanService _taiKhoanService;

        public TaiKhoanController(ITaiKhoanService taiKhoanService)
        {
            _taiKhoanService = taiKhoanService;
        }

        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<TaiKhoanResponseModel>>> GetAll([FromQuery] BasePaginationRequestModel model)
        {
            var result = await _taiKhoanService.GetAll(model);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoanResponseModel>> GetDetail(long id)
        {
            TaiKhoanResponseModel result = await _taiKhoanService.GetDetail(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> CreateOrUpdate([FromBody] CreateOrUpdateTaiKhoanModel model)
        {
            await _taiKhoanService.CreateOrUpdate(model);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _taiKhoanService.Delete(id);
            return Ok();
        }

    }
}
