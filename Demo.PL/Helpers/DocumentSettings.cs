using Microsoft.AspNetCore.Http;
using System;
using System.IO;
namespace Demo.PL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string FolderName)
        {
            string FolderPath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", FolderName);

            string FileName = $"{Guid.NewGuid()}{file.FileName}";

            string FilePath=Path.Combine(FolderPath,FileName);
            using (var fs = new FileStream(FilePath, FileMode.Create))

                    file.CopyTo(fs);

            return FileName;

        }

        public static void Delete(string FileName,string FolderName)
        {
            //1.Get File path
            var FilePath= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files",FolderName,FileName);

            //2.check if file exist?
            if(File.Exists(FilePath)) 
                File.Delete(FilePath);
        }
    }
}
