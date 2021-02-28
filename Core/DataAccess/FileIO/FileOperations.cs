using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.IO;

namespace Core.DataAccess.FileIO
{
    public class FileOperations
    {
        public static void SaveFile(string filePath, IFormFile file)
        {
            var path = Path.GetTempFileName();
            Console.WriteLine(path);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
