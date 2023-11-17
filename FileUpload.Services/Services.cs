using FileUploading.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public bool Fileupload(SingleFileModel model)
        {
             return _repository.Fileupload(model);
        }
        public List<SingleFileModel> CandidateDashBoard()
        {
            return _repository.CandidateDashBoard();
        }
        public SingleFileModel GetCandidateDetailById(int id)
        {
            return _repository.GetCandidateDetailById(id);
        }

    }
}
