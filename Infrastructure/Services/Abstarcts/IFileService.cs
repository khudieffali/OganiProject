using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Abstarcts
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile path);
        Task<string> DeleteFileChangeAsync(IFormFile file, string oldFileName, bool isArchive = false);
        Task<string> UpdateFileChangeAsync(IFormFile file, string oldFileName, bool isArchive = false);
        Task<string> ChangeAsync(IFormFile file, FileInfo fileInfo, string folder, string oldFileName, bool isArchive = false);
    }
}
