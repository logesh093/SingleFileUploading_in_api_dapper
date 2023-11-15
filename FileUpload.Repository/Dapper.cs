using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Repository
{
    internal class Dapper
    {
        public const String InsertData = "INSERT INTO Candidate_Detail (Name, Age, Qualification,File_Name,File_Content_Type,Candidate_FileData) VALUES (@name,@age,@qualification,@fname,@fcontenttype,@fdata)";
    }
}
