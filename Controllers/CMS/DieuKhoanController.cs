using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.DieuKhoanService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.DieuKhoanRequestModel;
using NS.Core.Models.ResponseModels.DieuKhoan;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class DieuKhoanController : ControllerBase
    {
        private readonly IDieuKhoanService _dieuKhoanService;
        public DieuKhoanController (IDieuKhoanService dieuKhoanService)
        {
            _dieuKhoanService = dieuKhoanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDieuKhoan()
        {
            DieuKhoanResponseModel result = await _dieuKhoanService.GetDieuKhoan();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create ([FromBody] DieuKhoanRequestModel dieuKhoanRequestModel)
        {
            await _dieuKhoanService.Create(dieuKhoanRequestModel);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] DieuKhoanRequestModel dieuKhoanRequestModel)
        {
            await _dieuKhoanService.Update(dieuKhoanRequestModel);
            return Ok();
        }
    }
}
