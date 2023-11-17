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
