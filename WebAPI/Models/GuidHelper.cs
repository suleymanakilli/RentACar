using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public static class GuidHelper
    {
        public static Tuple<string,string,string> GuidedPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string newPath = Guid.NewGuid().ToString() + fileExtension;
            string result = $"Images/{newPath}";
            string path = Environment.CurrentDirectory + @"\wwwroot\" + result;
            return new Tuple<string,string,string>(result,path,newPath);
        }
    }
}
