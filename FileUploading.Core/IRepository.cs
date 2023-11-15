
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploading.Core
{
    public interface IRepository
    {
        public void Fileupload(SingleFileModel model);
    }
}
