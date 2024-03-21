using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.FileService;
using NS.Core.Business.MenuConfigService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.MenuConfig;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.FileUpload;
using static Azure.Core.HttpHeader;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class MenuConfigController : ControllerBase
    {
        private readonly IMenuConfigService _menuConfig;
        private readonly IFile _fileService;

        public MenuConfigController(IMenuConfigService menuConfigService, IFile fileService)
        {
            _menuConfig = menuConfigService;
            _fileService = fileService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var resuilt = _menuConfig.GetMenuConfigById(id);
            return Ok(resuilt);
        }
        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> AddMenu([FromForm]MenuConfigRequestModel data) {
            var linkAnh = "";
            if (data.NewBanner != null )
            {
                FileUploadResponseModel res = await _fileService.UploadFile(data.NewBanner, Enums.FolderChild.TrangTinh);
                linkAnh = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
            }
            await _menuConfig.AddMenu(data,linkAnh);
            return Ok();
        }
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateMenu([FromForm] EditMenuConfigRequestModel data)
        {
            var linkAnh = "";
            if (data.NewBanner != null)
            {
                FileUploadResponseModel res = await _fileService.UploadFile(data.NewBanner, Enums.FolderChild.TrangTinh);
                linkAnh = string.Format(Constants.FileConstans.IMAGE_URL, $"{Request.Scheme}://{Request.Host.Value}/", res.Id);
            }
            await _menuConfig.UpdateMenu(data, linkAnh);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(long id)
        {
            await _menuConfig.DeleteMenu(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetList() {
            var resuit = await _menuConfig.GetAllAvailableDropDown();
             return Ok(resuit);
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllMenuConfigResponeModel>>> GetAllMenu() {
            var result = await _menuConfig.GetAllMenuConfigPage();
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllMenuConfigResponeModel>>> GetAllMenuActive()
        {
            var result = _menuConfig.GetAllMenuConfigIsActive();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult ShowHideMenuActive(long id)
        {
             _menuConfig.ShowHideMenuConfig(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllMenuConfigResponeModel>>> GetAllMenuConfigParent()
        {
            var result = _menuConfig.GetMenuConfigC1C2();
            return Ok(result);
        }
    }
}
