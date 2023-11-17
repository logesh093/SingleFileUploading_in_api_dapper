
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploading.Core
{
    public interface IRepository
    {
        public bool Fileupload(SingleFileModel model);
        public List<SingleFileModel> CandidateDashBoard();
        public SingleFileModel GetCandidateDetailById(int id);
    }
}
