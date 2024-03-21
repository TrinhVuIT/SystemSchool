using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NS.Core.Business.CoSoVatChatCMSService;
using NS.Core.Business.FileService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.CoSoVatChatCMSRequestModel;
using NS.Core.Models.ResponseModels.CoSoVatChat;
using NS.Core.Models.ResponseModels.FileUpload;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CoSoVatChatCMSController : ControllerBase
    {
        private readonly ICoSoVatChatCMSService _coSoVatChatCMSService;
        private readonly IConfiguration _configuration;
        private readonly IFile _fileService;
        public CoSoVatChatCMSController(ICoSoVatChatCMSService coSoVatChatCMSService, IConfiguration configuration, IFile fileService)
        {
            _coSoVatChatCMSService = coSoVatChatCMSService;
            _configuration = configuration;
            _fileService = fileService;

        }
        [HttpGet("{trangId}")]
        public async Task<IActionResult> GetPageCoSoVatChat(Enums.DanhSachTrangTinh trangId, [FromQuery] BasePaginationRequestModel input)
        {
            var res = await _coSoVatChatCMSService.GetPageCoSoVatChat(input, trangId);
            return Ok(res);
        }
        [HttpGet("{coSoVatChatId}")]
        public async Task<IActionResult> GetPageChiTietCoSoVatChat(long coSoVatChatId, [FromQuery] GetPageChiTietCoSoVatChatRequestModel input)
        {
            var res = await _coSoVatChatCMSService.GetPageChiTietCoSo(input, coSoVatChatId);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoSoVatChat([FromBody] DiaDiemRequestModel input)
        {
            await _coSoVatChatCMSService.CreateCoSoVatChat(input);
            return Ok();
        }   
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaResponseModel>> GetMediaById(long id)
        {
            var res = await _coSoVatChatCMSService.GetMediaById(id);
            return Ok(res);
        }
        
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateChiTietCoSoVatChat([FromForm] CreateMediaRequestModel input)
        {
            var files = Request.Form.Files;
            await _coSoVatChatCMSService.CreateMedia(input, files);
            return Ok();
        }
        
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateChiTietCoSoVatChat([FromForm] UpdateMediaRequestModel input )
        {
            var files = Request.Form.Files;
            await _coSoVatChatCMSService.UpdateMedia(input,files);
            return Ok();
        }
        
        [HttpPut("{coSoVatChatId}")]
        public async Task<IActionResult> UpdateCoSoVatChat([FromBody] DiaDiemRequestModel input, long coSoVatChatId)
        {
            await _coSoVatChatCMSService.UpdateCoSoVatChat(input, coSoVatChatId);
            return Ok();
        }

        [HttpDelete("{coSoVatChatId}")]
        public async Task<IActionResult> RemoveCoSoVatChat(long coSoVatChatId)
        {
            await _coSoVatChatCMSService.RemoveCoSoVatChat(coSoVatChatId);
            return Ok();
        }
        [HttpDelete("{chiTietCoSoVatChatId}")]
        public async Task<IActionResult> RemoveChiTietCoSoVatChat(long chiTietCoSoVatChatId)
        {
            await _coSoVatChatCMSService.RemoveMedia(chiTietCoSoVatChatId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrangThaiForOneCoSoVatChat([FromBody] DiaDiemRequestModel input)
        {
            await _coSoVatChatCMSService.UpdateTrangThaiForOneCoSoVatChat(input);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrangThaiForOneChiTiet([FromBody] UpdateMediaRequestModel input)
        {
            await _coSoVatChatCMSService.UpdateTrangThaiForOneChiTiet(input);
            return Ok();
        }
        [HttpGet("{coSoVatChatId}")]
        public async Task<IActionResult> GetCoSoVatChat(long coSoVatChatId)
        {
            var res = await _coSoVatChatCMSService.GetCoSoVatChat(coSoVatChatId);
            return Ok(res);
        }
    }
}
