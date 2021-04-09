using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities
{
    public class FileHelper
    {
        private static string _directory = Directory.GetCurrentDirectory() + "\\wwwroot";
        private static string folderName = "\\images\\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFile = Guid.NewGuid().ToString("N") + extension;
            if (!Directory.Exists(_directory+folderName))
            {
                Directory.CreateDirectory(_directory + folderName);
           }
            using (FileStream fileStream =File.Create(_directory+folderName+newFile))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (folderName + newFile).Replace("\\", "/");
        }
        public static string Update(IFormFile file, string OldImagePath)
        {
            Delete(OldImagePath);
            return Add(file);
          }
        public static void Delete(string ImagePath)
        {
            if (File.Exists(_directory+ImagePath.Replace("/","\\"))&&Path.GetFileName(ImagePath)!="default.png")
            {
                File.Delete(_directory + ImagePath.Replace("/", "\\"));
            }
        }

       
     
      }
}








