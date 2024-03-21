using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.FileService;
using NS.Core.Business.ThucDonService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.ThucDon;
using NS.Core.Models.ResponseModels.FileUpload;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ThucDonController : ControllerBase
    {
        private readonly IThucDonService _thucDonService;
        private readonly IFile _fileService;
        public ThucDonController (IThucDonService thucDonService,IFile fileService)
        {
            _thucDonService = thucDonService;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _thucDonService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAvailable()
        {
            var result = await _thucDonService.GetAllAvailable();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            var result = await _thucDonService.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetPagedThucDon([FromQuery] GetPagedThucDonRequestModel model)
        {
            var result = await _thucDonService.GetPagedThucDon(model);
            return Ok(result);
        }
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ThucDonRequestModel model)
        {
            FileUploadResponseModel res = await _fileService.UploadFile(model.LinkAnh, Enums.FolderChild.TrangTinh);
            var url = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
            await _thucDonService.Create(model, url);
            return Ok();
        }
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateThucDon([FromQuery] long id, [FromForm] ThucDonRequestModel model)
        {
            var url = "";
            if (model.LinkAnh != null)
            {
                FileUploadResponseModel res = await _fileService.UploadFile(model.LinkAnh, Enums.FolderChild.TrangTinh);
                url = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
            }
            await _thucDonService.UpdateThucDon(id,model, url);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateChiTietThucDon([FromQuery] long id, [FromBody] ChiTietThucDonRequestModel model)
        {
            await _thucDonService.UpdateChiTietThucDon(id, model);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _thucDonService.Delete(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetRelatedThucDon([FromQuery] DateTime startTime)
        {
            var result = await _thucDonService.GetRelatedThucDon(startTime);
            return Ok(result);
        }
    }
}
