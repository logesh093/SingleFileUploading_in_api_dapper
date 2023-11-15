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
        public IActionResult FileUpload(IFormFile file)
        {
            SingleFileModel model=new SingleFileModel();
            using (var client = new HttpClient())
            {
                
                if (file != null && file.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        file.CopyToAsync(stream);
                        model.filesview = stream.ToArray();
                    }
                    model.ContentType = file.ContentType;
                    model.filesname = file.FileName; 
                    client.BaseAddress = new Uri("https://localhost:7224/api/FileUploadAPI/Fileupload");
                    var checkresult = client.PostAsJsonAsync<SingleFileModel>(client.BaseAddress, model).Result;
                    
                    if (checkresult.IsSuccessStatusCode)
                    {
                        bool loginId = checkresult.Content.ReadFromJsonAsync<bool>().Result;
                        if (loginId)
                        {

                            TempData["Message"] = "File Uploaded Succuessfully... ";

                            return View();
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
    }
}
