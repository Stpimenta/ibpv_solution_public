using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazorise;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;

namespace IbpvFrontend.src.Services.ServiceUpload
{
    public class ServiceUploadGDrive : IServiceUpload
    {   
      
        private readonly DriveService _gDriveService;

        public ServiceUploadGDrive(IConfiguration configuration)
        {
   
            if(configuration["AmbienteVar:googledrivejsonpath"] is  null){
                throw new Exception("path google drive not found");
            }

            //recive path of json authorization
            string serviceTokenPath = configuration["AmbienteVar:googledrivejsonpath"]!;

        

            // Read the content of the authorization file into a memory buffer
            byte[] buffer;
            using (var stream = new FileStream(serviceTokenPath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }

            // Create GoogleCredential from the memory buffer
            var credential = GoogleCredential.FromJson(Encoding.UTF8.GetString(buffer))
                                            .CreateScoped(DriveService.ScopeConstants.DriveFile);

            //create Google Service
            _gDriveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "google drive",
            });
        }

       

        public async Task<string> upload(string IdfilePath, string fileName, Stream filestream, string contentType)
        {
            //create metadata google drive
            var metaData = new Google.Apis.Drive.v3.Data.File()
            {
                Name = fileName,
                Parents = new List<string> {IdfilePath}
            };
    

            //create mediaupload request to upload
            FilesResource.CreateMediaUpload request;
            filestream.Position = 0;
            request = _gDriveService.Files.Create(metaData,filestream,contentType);
            request.Fields = "id";
            request.ProgressChanged += (IUploadProgress progress) => Request_ProgressChanged1(progress);
            //send request to upload
            await request.UploadAsync();
            //get file name and return
            var file = request.ResponseBody;
            return file.Id;

        }
        public event Action<UploadStatus>? UploadProgressChanged;
        
        private void Request_ProgressChanged1(IUploadProgress progress)
        {
            //UploadProgressChanged.Invoke(progress.Status.ToString());
            // Aqui você pode acessar as propriedades do progresso do upload
            UploadProgressChanged?.Invoke(progress.Status);
        }
    }
}