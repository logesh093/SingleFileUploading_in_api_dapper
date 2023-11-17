namespace FileUploading.Models
{
    public class SingleFileModel
    {
        public IFormFile file {  get; set; }
        public int id { get; set; }
        public string filesname { get; set; }
        public byte[] filesview { get; set; }
        public string ContentType { get; set;}
        public string Name { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
    }
}
