using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FileUploading.Core
{
    public class SingleFileModel
    {
        
        public string filesname { get; set; }
        public int id { get; set; }
        public byte[] filesview { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
    }
}
