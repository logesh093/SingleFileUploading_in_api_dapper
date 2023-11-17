
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
using System.Security.Cryptography;

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
        public bool Fileupload(SingleFileModel model)
        {
            if (model != null)
            {

                using (var connections = Connection)
                {
                    connections.Query<SingleFileModel>(Dapper.InsertData, new
                    {
                        @candidatename=model.Name,
                        @age=model.Age,
                        @qualification = model.Qualification,
                        @fname=model.filesname,
                        @byte=model.filesview,
                        @contenttype=model.ContentType

                    }).SingleOrDefault();
                   
                     return true;
                }
            }
            return false;
        }
        public List<SingleFileModel> CandidateDashBoard()
        {
            using (var connections = Connection)
            {
                var Candidatelist = (connections.Query<SingleFileModel>(Dapper.DisplayData)).ToList();

                return Candidatelist;
            }
        }

        public SingleFileModel GetCandidateDetailById(int id)
        {
            using (var connections = Connection)
            {
                var CandidateData = (connections.Query<SingleFileModel>(Dapper.GetDataById,
                new
                {
                    @id = id,
                })).SingleOrDefault();
                return CandidateData;
            }
        }
    }
    
}
