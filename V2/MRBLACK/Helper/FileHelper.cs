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

        //public static async Task<string> UploadFile(IFormFile FormFile)
        //{
        //    try
        //    {
        //        if(FormFile == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
        //            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", FormFile.FileName);
        //            using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
        //            {
        //                await FormFile.CopyToAsync(stream);
        //            }
        //            return path;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}
    }
}
