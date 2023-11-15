using FileUploading.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public class Services : IServices
    {
        private readonly IRepository _repository;
        public Services(IRepository repository)
        {
            _repository = repository;
        }
        public void Fileupload(SingleFileModel model)
        {
             _repository.Fileupload(model);
        }
        
    }
}
