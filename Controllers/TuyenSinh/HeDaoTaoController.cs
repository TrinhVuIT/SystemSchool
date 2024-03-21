
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NS.Core.Business.HeDaoTaoService;
using NS.Core.Models.Entities;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace NS.Core.API.Controllers
{
    [Route(Commons.Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class HeDaoTaoController : ControllerBase
    {
        private readonly IHeDaoTaoService _heDaoTaoService;

        public HeDaoTaoController(IHeDaoTaoService heDaoTaoServices)
        {
            _heDaoTaoService = heDaoTaoServices;
        }
        [HttpGet("{heDaoTaoId}")]
        public Task<HeDaoTaoResponseModel> GetHeDaoTaoById(long heDaoTaoId)
        {

            return _heDaoTaoService.GetById(heDaoTaoId);
        }
        [HttpGet]
        public async Task<ActionResult<List<HeDaoTaoResponseModel>>> GetAll()
        {
            return await _heDaoTaoService.GetAll();
        }
        [HttpPost]
        public async Task<IActionResult> CreateHeDaoTao([FromBody] CreateOrUpdateHeDaoTaoModel data)
        {
            await _heDaoTaoService.CreateHeDaoTao(data);
            return Ok();
        }
        [HttpPut("{heDaoTaoId}")]
        public async Task<IActionResult> UpdateHeDaoTao(long heDaoTaoId, CreateOrUpdateHeDaoTaoModel data)
        {
            await _heDaoTaoService.UpdateHdt(heDaoTaoId, data);
            return Ok();
        }
        [HttpDelete]
        public async void DeleteHeDaoTao([FromQuery] long heDaoTaoId)
        {
            await _heDaoTaoService.DeleteHdt(heDaoTaoId);

        }
        [HttpGet]
        public async Task<ActionResult<List<HeDaoTaoResponseModel>>> GetPagedHeDaoTao([FromQuery] HeDaoTaoRequestModel input)
        {
            var result = await _heDaoTaoService.GetPagedHeDaoTao(input);
            return Ok(result);
        }
    }
      
}
