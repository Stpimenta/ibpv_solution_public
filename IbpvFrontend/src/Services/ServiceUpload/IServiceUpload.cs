using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Upload;

namespace IbpvFrontend.src.Services.ServiceUpload
{
    public interface IServiceUpload
    {
        public event Action<UploadStatus> UploadProgressChanged;
        public Task<string>upload(string IdfilePath,string fileName, Stream filestream, string contentType);
        
    }
}