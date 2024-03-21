using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.VideoService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.landingPage;
using NS.Core.Models.ResponseModels.LandingPage;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.Video;
using NS.Core.Models.RequestModels.Video;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class VideoController : ControllerBase
    {
        public readonly IVideo _videoCMSService;

        public VideoController(IVideo videoCMSService)
        {
            _videoCMSService = videoCMSService;
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<VideoCMSResponseModel>>> GetVideo([FromQuery] GetPageVideoResquestModel model)
        {
            var result = await _videoCMSService.GetAllVideoCMS(model);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<VideoCMSResponseModel>> GetVideoById(long idVideo)
        {
            var result = await _videoCMSService.GetVideoById(idVideo);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]VideoCMSRequestModel input)
        {
            try
            {
                await _videoCMSService.CreateVideo(input);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(long idVideo, [FromBody]VideoCMSRequestModel input)
        {
            await _videoCMSService.UpdateVideo(idVideo, input);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long idVideo)
        {
            await _videoCMSService.DeleteVideo(idVideo);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PheDuyet(long idVideo)
        {
            await _videoCMSService.DuyetVideo(idVideo);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> HienThi(long idVideo)
        {
            await _videoCMSService.HienThiVideo(idVideo);
            return Ok();
        }
    }
}
