using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.MediaService;
using NS.Core.Commons;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            var res = await _mediaService.GetById(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _mediaService.GetAll();
            return Ok(res);
        }
    }
}
