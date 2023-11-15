
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FileUploading.Core;
using System.Data;
using Microsoft.Extensions.Configuration;
using Azure;
using System.Xml.Linq;
using Dapper;
using FileUploading.Core.model;

namespace FileUpload.Repository
{
    public class Repository : IRepository
    {
        private readonly IConfiguration _configure;
        public IDbConnection Connection => new SqlConnection(_configure.GetConnectionString("DefaultConnection"));
        public Repository(IConfiguration configure)
        {
            _configure = configure;
        }
        public void Fileupload(SingleFileModel model)
        {
            //model.File_Name = model.File.FileName;
            //using (var stream = new MemoryStream())
            //{

            //    model.File.CopyTo(stream);
            //    model.Candidate_FileData=stream.ToArray();
            //}

            //model.File_Content_Type = "";
            //switch (Path.GetExtension(model.File_Name))
            //{
            //    case ".jpg":
            //        model.File_Content_Type = "image/jpeg";
            //        break;
            //    case ".png":
            //        model.File_Content_Type = "image/png";
            //        break;
            //    case ".gif":
            //        model.File_Content_Type = "image/gif";
            //        break;
            //    case ".bmp":
            //        model.File_Content_Type = "image/bmp";
            //        break;
            //    case ".pdf":
            //        model.File_Content_Type = "application/pdf";
            //        break;
            //    case ".doc":
            //        model.File_Content_Type = "application/vnd.ms-word";
            //        break;
            //    case ".docx":
            //        model.File_Content_Type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            //        break;
            //}
            //using (IDbConnection connections = Connection)
            //{
            //    var result = connections.Execute(Dapper.InsertData, new
            //    {
            //        @name = model.Name,
            //        @age = model.Age,
            //        @qualification = model.Qualification,
            //        @fname = model.File_Name,
            //        @fcontenttype = model.File_Content_Type,
            //        @fdata = model.Candidate_FileData
            //    });
            //}


        }
    }
    
}
