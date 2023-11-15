using FileUploading.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FileUploading.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadAPIController : ControllerBase
    {
        private readonly IServices _services;

        public FileUploadAPIController(IServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("Fileupload")]
        public IActionResult Fileupload(SingleFileModel model)
        {
            bool stu_services.Fileupload(model);
            return Ok(true);
        }
    }
}
