using FileUploading.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNet.SignalR.Infrastructure;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.EMMA;
using System.Net.Http.Json;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Reflection.Metadata;
using System.Text.Json;
using Newtonsoft.Json;

namespace FileUploading.Controllers
{
    public class FileInsertingController : Controller
    {
        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FileUpload(SingleFileModel model)
        {
            
            using (var client = new HttpClient())
            {
                
                if (model.file != null && model.file.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        model.file.CopyToAsync(stream);
                        model.filesview = stream.ToArray();
                    }
                    model.ContentType = model.file.ContentType;
                    model.filesname = model.file.FileName; 
                    client.BaseAddress = new Uri("https://localhost:7224/api/FileUploadAPI/Fileupload");
                    var checkresult = client.PostAsJsonAsync<SingleFileModel>(client.BaseAddress, model).Result;
                    
                    if (checkresult.IsSuccessStatusCode)
                    {
                        bool loginId = checkresult.Content.ReadFromJsonAsync<bool>().Result;
                        if (loginId)
                        {

                            TempData["Message"] = "File Uploaded Succuessfully... ";

                            return RedirectToAction("CandidateDashBoard");
                        }
                        else
                        {
                            TempData["Message"] = "Unable to upload!!!";
                            return View();
                        }
                    }
                    
                }
                return View();
            }
        }
        public IActionResult CandidateDashBoard()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/FileUploadAPI/CandidateDashBoard");
                var Posttask = client.GetAsync(client.BaseAddress);
                Posttask.Wait();
                var checkresult=Posttask.Result;

                if (checkresult.IsSuccessStatusCode)
                {
                    var result = checkresult.Content.ReadFromJsonAsync<List<SingleFileModel>>().Result;

                    return View(result);
                }
                return View();

            }

        }

        public IActionResult DownloadResume(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/FileUploadAPI/GetCandidateDetailById");
                var checkresult = client.GetAsync("GetCandidateDetailById?id=" + id).Result;
                if (checkresult.IsSuccessStatusCode)
                {
                    var result = checkresult.Content.ReadFromJsonAsync<SingleFileModel>().Result;
                    ViewBag.FileName = result.filesname;
                    return File(result.filesview, result.ContentType, result.filesname);
                }
                return View("CandidateDashBoard");

            }

        }
        public IActionResult PreviewResume(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/FileUploadAPI/GetCandidateDetailById");
                var checkresult = client.GetAsync("GetCandidateDetailById?id=" + id).Result;
                if (checkresult.IsSuccessStatusCode)
                {
                    var result = checkresult.Content.ReadFromJsonAsync<SingleFileModel>().Result;
                    ViewBag.bytefile = result.filesview;
                    ViewBag.ContentType = result.ContentType;
                    //var fileContentResult = new FileContentResult(result.filesview, result.ContentType);
                    return PartialView();
                }

                return View("CandidateDashBoard");
            }
        }
        //public IActionResult PreviewResume(int id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7224/api/FileUploadAPI/GetCandidateDetailById");
        //        var checkresult = client.GetAsync("GetCandidateDetailById?id=" + id).Result;
        //        if (checkresult.IsSuccessStatusCode)
        //        {
        //            var result = checkresult.Content.ReadFromJsonAsync<SingleFileModel>().Result;
        //            ViewBag.FileName = result.filesname;
        //            return new FileContentResult(result.filesview, result.ContentType);
        //        }
        //        return View("CandidateDashBoard");
        //    }
        //
        //}
    }
}
