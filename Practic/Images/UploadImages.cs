using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;

namespace Shop.NewFolder
{
    public static class UploadImages
    {
        public static string SaveFile(IFormFile file, string Foldername)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + $@"\{Foldername}");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string savename = Guid.NewGuid().ToString() + file.FileName;

            var saveUrl = $"/{Foldername}/{savename}";


            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Foldername)).Root + $@"\{savename}";

            using (FileStream fs = File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return saveUrl;
        }

    }
}
