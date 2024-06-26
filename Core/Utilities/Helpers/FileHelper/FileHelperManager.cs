using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string Update(IFormFile file, string path, string root)
        {
            Delete(path);
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length <= 0) return null;

            if (!Directory.Exists(root)) Directory.CreateDirectory(root);

            string existion = Path.GetExtension(file.FileName);
            string guid = GuidHelper.CreateGuid();
            string path = guid + existion;
            using (FileStream fs = File.Create(root + path))
            {
                file.CopyTo(fs);
                fs.Flush();
                return path;
            }
        }


    }
}
