using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business;
using NS.Core.Business.FileService;
using NS.Core.Commons;
using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels;
using NS.Core.Models.ResponseModels.FileUpload;
using System.IO;
using System.Reflection.Metadata;


namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFile _fileService;
        private readonly IConfiguration _configuration;

        public FileController(IFile fileService, IConfiguration configuration)
        {
            _fileService = fileService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<FileUploadResponseModel>> Upload([FromForm]IFormFile file)
        {
            FileUploadResponseModel res = await _fileService.UploadFile(file,Enums.FolderChild.TrangTinh);
            return Ok(res);
        }

        [HttpPost]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<UploadFromCkResModel> UploadFromCk([FromForm(Name = "upload")]IFormFile file)
        {
            FileUploadResponseModel res = await _fileService.UploadFile(file, Enums.FolderChild.BaiViet);
            var dir = Path.GetFullPath(_configuration[Constants.FileConstans.STORED_FILES_PATH]);

            var url = "/" + dir.Split('\\').Last() + "/" + nameof(Enums.FolderChild.BaiViet) + "/" + res.FileName;

            return new UploadFromCkResModel
            {
                Url = url
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileUploadResponseModel>> GetById(long id)
        {
            FileUploadResponseModel file = await _fileService.GetById(id);

            return Ok(file);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(long id)
        {
            try
            {
                Byte[] file = await _fileService.GetFileByteArray(id);
                
                return Ok(file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImages(long id)
        {
            try
            {
                Byte[] file = await _fileService.GetFileByteArray(id);
                
                return File(file, "image/png");;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}