using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.CMS.ThanhTichNoiBatService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.ThanhTichNoiBat;

namespace NS.Core.API.Controllers.CMS
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ThanhTichNoiBatController : ControllerBase
    {
        private readonly IThanhTichNoiBatService _thanhTichNoiBatService;
        public ThanhTichNoiBatController(IThanhTichNoiBatService thanhTichNoiBatService)
        {
            _thanhTichNoiBatService = thanhTichNoiBatService;
        }

        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CreateOrUpdateThanhTichNoiBat data)
        {
            await _thanhTichNoiBatService.Create(data);
            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> Update(long id, [FromForm] CreateOrUpdateThanhTichNoiBat data)
        {
            await _thanhTichNoiBatService.Update(data, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _thanhTichNoiBatService.Delete(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _thanhTichNoiBatService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _thanhTichNoiBatService.GetById(id));
        }
    }
}
