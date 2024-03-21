using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.BinhLuanServices;
using NS.Core.Business.TinTucServices;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using static NS.Core.Commons.Enums;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private readonly IBinhLuanServices _binhLuanServices;
        public BinhLuanController(IBinhLuanServices binhLuanServices)
        {
            _binhLuanServices = binhLuanServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddBinhLuan([FromBody] CreateOrUpdateBinhLuan data)
        {
            await _binhLuanServices.CreateBinhLuan(data);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBinhLuan(long id, [FromBody] CreateOrUpdateBinhLuan data)
        {
            await _binhLuanServices.UpdateBinhLuan(id, data);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBinhLuan(long id)
        {
            await _binhLuanServices.DeleteBinhLuan(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<BinhLuanResponseModel>>> GetPagedBinhLuan([FromQuery] GetPagedBinhLuanRequesModel input)
        {
            var result = await _binhLuanServices.GetPagedBinhLuan(input);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BinhLuanResponseModel>> PheDuyetBinhLuan(long id, [FromBody] TrangThaiBinhLuan trangThai)
        {
            await _binhLuanServices.PheDuyetBinhLuan(id, trangThai);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BinhLuanResponseModel>> GetById(long id)
        {
            var ret = await _binhLuanServices.GetBinhLuanById(id);
            return Ok(ret);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BinhLuanResponseModel>> ShowHideBinhLuan(long id)
        {
            await _binhLuanServices.ShowHideBinhLuan(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<BinhLuanResponseModel>>> GetPagedBinhLuanActive([FromQuery] GetPagedBinhLuanRequesModel input)
        {
            var result = await _binhLuanServices.GetPagedBinhLuanActive(input);
            return Ok(result);
        }
    }
}
