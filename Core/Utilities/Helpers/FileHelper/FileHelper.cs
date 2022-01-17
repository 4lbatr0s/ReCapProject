using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string fileName)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public string Update(IFormFile file, string fileName, string root)
        {
            if(File.Exists(fileName)) // if file exists
            {
                File.Delete(fileName); // delete the file and use upload method to upload new file
            }
            return  Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if(file.Length>0) //is a file sent? check.
            {
                if(!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root); // if a directory with the name root does not exist, then create the directory
                }

                string extension = Path.GetExtension(file.FileName); //we get the extension of the file we are going to upload.
                string guid = Guid.NewGuid().ToString();
                string fileName = guid + extension; // for example: extension is .txt, guid is 1bw213...231 your filePath is 1bw123...213.txt
                
                //root: folder's name, filePath = file's name
                using(FileStream  fileStream = File.Create(root + fileName)) //create a file on 'root\fileName
                {
                    file.CopyTo(fileStream); //Copies file to fileStream 
                    fileStream.Flush(); // delete from ram, sends to the root/fileName
                    return fileName; //we will add our file's name to the sql server

                }
            }
            return null;
        }
    }
}
