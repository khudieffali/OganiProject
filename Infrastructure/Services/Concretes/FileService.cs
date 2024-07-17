using Infrastructure.Commons.Abstracts;
using Infrastructure.Services.Abstarcts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Concretes
{
    public class FileService(IHostEnvironment webHost) : IFileService
    {
        private readonly IHostEnvironment _webHost = webHost;

        public async Task<string> UploadFileAsync(IFormFile path)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(path.FileName)}";
            var phsycialPath = Path.Combine(_webHost.ContentRootPath, "wwwroot", "uploads", "images", fileName);
            using FileStream stream = new(phsycialPath, FileMode.CreateNew, FileAccess.Write);
            await path.CopyToAsync(stream);
            return fileName;
        }

        public async Task<string> DeleteFileChangeAsync(IFormFile file, string oldFileName, bool isArchive = false)
        {
            var folder = Path.Combine(_webHost.ContentRootPath, "wwwroot", "uploads", "images");
            FileInfo fileInfo = new(Path.Combine(folder, oldFileName));
            if (file == null)
            {
                var deleteFileName = $"archive-{oldFileName}";
                fileInfo.MoveTo(Path.Combine(folder, deleteFileName));
                return oldFileName;
            }
            return await ChangeAsync(file, fileInfo, folder, oldFileName);

        }
        public async Task<string> UpdateFileChangeAsync(IFormFile file, string oldFileName, bool isArchive = false)
        {
            if (file == null) return oldFileName;
            var folder = Path.Combine(_webHost.ContentRootPath, "wwwroot", "uploads", "images");
            FileInfo fileInfo = new(Path.Combine(folder, oldFileName));
            return await ChangeAsync(file, fileInfo, folder, oldFileName);
        }
        public async Task<string> ChangeAsync(IFormFile file, FileInfo fileInfo, string folder, string oldFileName, bool isArchive = false)
        {


            if (fileInfo.Exists && isArchive)
            {
                var newFileName = $"archive-{oldFileName}";
                fileInfo.MoveTo(Path.Combine(folder, newFileName));
            }
            else if (fileInfo.Exists && !isArchive)
            {
                fileInfo.Delete();
            }
            return await UploadFileAsync(file);
        }
    }
}
