using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MRBLACK.Helper
{
    public static class FileHelper
    {
        public static string UploadFile(IFormFile FormFile, IWebHostEnvironment webHostEnvironment, string savedFolderPath)
        {
            string uniqueFileName = null;

            if (FormFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, savedFolderPath);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + FormFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    FormFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public static string CreateBookDir(IWebHostEnvironment webHostEnvironment, string bookName)
        {
            string bookFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads/Books/" + bookName);
            if (!Directory.Exists(bookFolder))
            {
                Directory.CreateDirectory(bookFolder);
            }
            return bookFolder;
        }

        public static string UploadBookFile(IWebHostEnvironment webHostEnvironment,string bookName,IFormFile FormFile)
        {
            string uniqueFileName = null;
            if (FormFile != null)
            {
                var bookFolder = CreateBookDir(webHostEnvironment, bookName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + FormFile.FileName;
                string filePath = Path.Combine(bookFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    FormFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
