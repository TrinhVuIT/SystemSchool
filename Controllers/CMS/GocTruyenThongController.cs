using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.FileService;
using NS.Core.Business.GocTruyenThongService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.GocTruyenThong;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.FileUpload;
using NS.Core.Models.ResponseModels.GocTruyenThong;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class GocTruyenThongController : ControllerBase
    {
        private readonly IGocTruyenThongService _gocTruyenThongService;

        private readonly IFile _fileService;
        public GocTruyenThongController (IGocTruyenThongService gocTruyenThongService, IFile fileService)
        {
            _gocTruyenThongService = gocTruyenThongService;
            _fileService = fileService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await Task.FromResult(_gocTruyenThongService.GetAllAvailable());
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            var res = await Task.FromResult(_gocTruyenThongService.GetById(id));
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateData(GocTruyenThongRequestModel model)
        {
            await _gocTruyenThongService.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData(long id, GocTruyenThongRequestModel model)
        {
            await _gocTruyenThongService.Update(id, model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> DeleteData(long id)
        {
            await _gocTruyenThongService.Delete(id);
            return Ok();
        }
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateCMS([FromForm] GocTruyenThongCMSRequestModel model)
        {
   
            await _gocTruyenThongService.CreateCMS(model);
            return Ok();
        }
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateCMS([FromForm] EditGocTruyenThongCMSRequestModel model)
        {
           await _gocTruyenThongService.UpdateCMS(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<GocTruyenThongResponseModel>>> GetPageGocTruyenThong([FromQuery] GetPagedGocTruyenThongReqModel page)
        {
            var res = await _gocTruyenThongService.GetPaged(page);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetSuKienTruyenThongNoiBat()
        {
            var res = await Task.FromResult(_gocTruyenThongService.GetSuKienTruyenThongNoiBat());
            return Ok(res);
        }
    }
}
