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
        private readonly IConfiguration _configuration;
        public FileUploadAPIController(IServices services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }
       
        
        [HttpGet]
        [Route("GetIsLive")]
        public bool GetIsLive()
        {
            var IsLive = _configuration.GetValue<bool>("IsLive");
            return IsLive;
        }

        [HttpPost]
        [Route("Fileupload")]
        public IActionResult Fileupload(SingleFileModel model)
        {
            bool status = _services.Fileupload(model);
            return Ok(status);
        }
        #region Candidate Dashboard
        [HttpGet]
        [Route("CandidateDashBoard")]
        public IActionResult CandidateDashBoard()
        {
            var getCandidateList = _services.CandidateDashBoard();
            return Ok(getCandidateList);
        }
        #endregion
        #region Get Candidate Detail By id
        [HttpGet]
        [Route("GetCandidateDetailById")]
        public IActionResult GetCandidateDetailById(int id)
        {
            var getCandidateDetail = _services.GetCandidateDetailById(id);
            return Ok(getCandidateDetail);
        }
        #endregion
    }
}
