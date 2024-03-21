using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.FileService;
using NS.Core.Business.TinTucServices;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.TinTucRequest;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.FileUpload;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly ITinTucServices _tinTucService;
        private readonly IFile _fileService;
        public BaiVietController(ITinTucServices tinTucService,IFile fileService)
        {
            _tinTucService = tinTucService;
            _fileService = fileService;
        }
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> AddbaiViet([FromForm] AddTinTucRequestModel data)
        {

            FileUploadResponseModel res = await _fileService.UploadFile(data.AnhDaiDien, Enums.FolderChild.TrangTinh);
            var url = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
            _tinTucService.CreateBaiViet(data, url);
            return Ok();
        }
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateBaiViet([FromForm] UpdateTinTucRequestModel data)
        {

            var url = "";
            if (data.AnhDaiDien != null)
            {
                FileUploadResponseModel res = await _fileService.UploadFile(data.AnhDaiDien, Enums.FolderChild.TrangTinh);
                url = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
            }
            await _tinTucService.UpdateBaiViet(data, url);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiViet(long id)
        {
            await _tinTucService.DeleteTinTuc(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TinTucResponseModel>> GetBaiVietById(string id)
        {
            var ret = await _tinTucService.GetTinTucById(id);
            return Ok(ret);
        }
        [HttpGet]
        public async Task<ActionResult<List<TinTucResponseModel>>> GetPagedBaiViet([FromQuery] GetPagedTinTucRequestModel input)
        {
            var result = await _tinTucService.GetPageBaiViet(input);
            return Ok(result);
        }
    }
}
