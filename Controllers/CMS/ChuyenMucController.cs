using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.ChuyenMucServices;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ChuyenMucController : ControllerBase
    {
        private readonly IChuyenMucServices _chuyenMucServices;

        public ChuyenMucController(IChuyenMucServices chuyenMucServices)
        {
            _chuyenMucServices = chuyenMucServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<ChuyenMucResponeModel>>> GetPagedChuyenMuc([FromQuery] GetPageChuyenMucResponseModel input)
        {
            var result = await _chuyenMucServices.GetPagedChuyeMuc(input);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<ChuyenMucResponeModel>>> GetAll()
        {
            var result = await _chuyenMucServices.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuyenMucResponeModel>> GetById( long id)
        {
            var ret = await _chuyenMucServices.GetById(id);
            return Ok(ret);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ChuyenMucResponeModel>> UpdateChuyenMuc(long id, [FromBody] CreateChuyenMucRequestModel chuyenMuc)
        {
            await _chuyenMucServices.UpdateChuyenMuc(id, chuyenMuc);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<ChuyenMucResponeModel>> AddNewChuyenMuc([FromBody] CreateChuyenMucRequestModel model)
        {
            await _chuyenMucServices.AddNewChuyenMuc(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task DeleteChuyenMuc(long id)
        {
             await _chuyenMucServices.DeleteChuyenMuc(id);         
        }
        
    }
}
