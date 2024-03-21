using Microsoft.AspNetCore.Mvc;
using NS.Core.Business;
using NS.Core.Business.FileService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.FileUpload;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ThongTinTruongController : ControllerBase
    {
        private readonly IThongTinTruongServices _thongTinTruongServices;
        private readonly IFile _fileService;
        public ThongTinTruongController(IThongTinTruongServices thongTinTruongServices, IFile fileService)
        {
            _thongTinTruongServices = thongTinTruongServices;
            _fileService = fileService;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateThongTinTruong([FromBody]ThongTinTruongReqModel input)
        {
            await _thongTinTruongServices.UpdateThongTinTruong(input);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<TinTucResponseModel>>>  GetFooter()
        {
            var res =await _thongTinTruongServices.GetFooter();
            return Ok(res);
        }
    }
}
