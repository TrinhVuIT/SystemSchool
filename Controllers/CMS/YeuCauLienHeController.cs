using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.YeuCauLienHeService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class YeuCauLienHeController : ControllerBase
    {
        public readonly IYeuCauLienHeService _yeuCauLienHeService;
        public YeuCauLienHeController (IYeuCauLienHeService yeuCauLienHeService)
        {
            _yeuCauLienHeService = yeuCauLienHeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<YeuCauLienHeResponseModel> result = await _yeuCauLienHeService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedYeuCauLienHe([FromQuery] GetPagedYeuCauLienHeRequestModel input)
        {
            var result = await _yeuCauLienHeService.GetPagedYeuCauLienHe(input);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetALlAvailable()
        {
            List<YeuCauLienHeResponseModel> result = await _yeuCauLienHeService.GetAllAvailable();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> YeuCauLienHeDetail([FromQuery] long id)
        {
            YeuCauLienHeResponseModel result = await _yeuCauLienHeService.YeuCauLienHeDetail(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            YeuCauLienHeResponseModel result = await _yeuCauLienHeService.GetById(id);
            return Ok(result);
        }

        [HttpPost] 
        public async Task<IActionResult> Create([FromBody] YeuCauLienHeRequestModel model)
        {
            await _yeuCauLienHeService.Create(model);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeRespondedStatus([FromQuery] long id)
        {
            await _yeuCauLienHeService.ChangeRespondedStatus(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _yeuCauLienHeService.Delete(id);
            return Ok();
        }
    }
}
