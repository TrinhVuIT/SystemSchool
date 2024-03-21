using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.CaiDatTrang;
using NS.Core.Commons;
using NS.Core.Models.RequestModels.CaiDatTrang;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CaiDatTrangController : ControllerBase
    {
        private readonly ICaiDatTrangService _caiDatTrangService;
        public CaiDatTrangController(ICaiDatTrangService caiDatTrangService)
        {
            _caiDatTrangService = caiDatTrangService;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTrang(long id, TrangRequestModel data)
        {
            await _caiDatTrangService.SuaTrang(id, data);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrangById(long id)
        {
            var result = await _caiDatTrangService.GetTrangById(id);
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ThemChiTiet(CreateCaiDatChiTietRequestModel data,long id)
        {
            await _caiDatTrangService.ThemCaiDatChiTiet(data,id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaChiTiet(long id)
        {
            await _caiDatTrangService.XoaCaiDatChiTiet(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaiDatTongTheById(long id)
        {
            var result = await _caiDatTrangService.GetCaiDatTongTheById(id);
            return Ok(result);
        }

    }
}
