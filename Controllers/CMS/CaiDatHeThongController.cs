using Microsoft.AspNetCore.Mvc;
using NS.Core.Business;
using NS.Core.Business.CaiDatHeThongServices;
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
    public class CaiDatHeThongController : ControllerBase
    {
        private readonly ICaiDatHeThongServices _caiDatHeThongServices;
        private readonly IFile _fileService;
        public CaiDatHeThongController(ICaiDatHeThongServices thongTinTruongServices, IFile fileService)
        {
            _caiDatHeThongServices = thongTinTruongServices;
            _fileService = fileService;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmailConfig([FromBody] CaiDatHeThongModel input)
        {
            await _caiDatHeThongServices.UpdateCauHinhEmail(input);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<CaiDatHeThongModel>>> GetEmailConFig()
        {
            var result = await Task.FromResult(_caiDatHeThongServices.GetAllCauHinhEmail());
            return Ok(result);
        }

    }
}
