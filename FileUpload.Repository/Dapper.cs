using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Repository
{
    public class Dapper
    {
        public const String InsertData = "INSERT INTO File_Upload(Name,Age,Qualification,File_Name,Byte_File,Content_Type)VALUES(@candidatename,@age,@qualification,@fname,@byte,@contenttype)";
        public const String DisplayData = "SELECT Candidate_Id as id, Name as Name,Age as Age,Qualification as Qualification,File_Name as filesname,Byte_File as filesview,Content_Type as ContentType FROM File_Upload";
        public const String GetDataById = "SELECT Candidate_Id as id, Name as Name,Age as Age,Qualification as Qualification,File_Name as filesname,Byte_File as filesview,Content_Type as ContentType FROM File_Upload WHERE Candidate_Id=@id";
    }
}
