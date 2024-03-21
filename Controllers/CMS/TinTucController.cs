using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.FileService;
using NS.Core.Business.TinTucServices;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.TinTucRequest;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.FileUpload;
using static NS.Core.Commons.Enums;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TinTucController : ControllerBase
    {
        private readonly ITinTucServices _tinTucServices;
        private readonly IFile _fileService;
        public TinTucController(ITinTucServices tinTucServices, IFile fileService)
        {
            _tinTucServices = tinTucServices;
            _fileService = fileService;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTinTuc(long id)
        {
            await _tinTucServices.DeleteTinTuc(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<TinTucResponseModel>>> GetPagedTinTuc([FromQuery] GetPagedTinTucRequestModel input)
        {
            var result = await _tinTucServices.GetPagedTinTuc(input);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<TinTucResponseModel>>> GetPagedTinTruyenThong([FromQuery] GetPagedTinTucRequestModel input)
        {
            var result = await _tinTucServices.GetPagedTinTruyenThong(input);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TinTucResponseModel>> PheDuyetTinTuc(long id, [FromBody] TrangThaiTinTuc trangThai )
        {
            await _tinTucServices.PheDuyetTinTuc(id, trangThai);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TinTucResponseModel>> GetById(string id)
        {
            var ret =await _tinTucServices.GetTinTucById(id);
            return Ok(ret);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TinTucResponseModel>> ShowHideTinTuc(long id)
        {
            await _tinTucServices.ShowHideTinTuc(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<TinTucResponseModel>>> GetALlTinTucNoiBat()
        {
            var result = _tinTucServices.GetAllTinTucNoiBat();
            return Ok(result);
        }
        
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateOrUpdateTinTuc([FromForm]CreateOrUpdateTinTucRequestModel model)
        {
           await _tinTucServices.CreateOrUpdateTinTuc(model);
            return Ok();
        }   
        
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> AddTinTuc([FromForm]AddTinTucRequestModel data)
        {

            FileUploadResponseModel res = await _fileService.UploadFile(data.AnhDaiDien, Enums.FolderChild.TrangTinh);
            var url = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
           _tinTucServices.CreateTinTuc(data, url);
            return Ok();
        }
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateTinTuc([FromForm] UpdateTinTucRequestModel data)
        {

            var url = "";
            if(data.AnhDaiDien != null)
            {
                FileUploadResponseModel res = await _fileService.UploadFile(data.AnhDaiDien, Enums.FolderChild.TrangTinh);
                 url = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
            }
            await _tinTucServices.UpdateTinTuc(data, url);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<TinTucResponseModel>>> GetPagedTinTucActive([FromQuery] GetPagedTinTucRequestModel input)
        {
            var result = await _tinTucServices.GetPagedTinTucActive(input);
            return Ok(result);
        }
    }
}
