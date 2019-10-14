using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EShopWebUI.Controllers.Helpers
{
    public static class ImageHelper
    {
        public static string RenameFileToUnique(string currentFilePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(currentFilePath);
            string fileExtension = Path.GetExtension(currentFilePath);

            var existingFiles = GetExistingFileNames(Path.GetDirectoryName(currentFilePath));

            while(existingFiles.Contains(fileName))
                fileName = GenerateRandomName();

            FileInfo file = new FileInfo(currentFilePath);
            file.Rename(fileName + fileExtension);

            return fileName + fileExtension;
        }

        public static List<string> GetExistingFileNames(string path)
        {
            var existingFileNames = new List<string>();
            List<string> files = Directory.GetFiles(path).ToList();
            foreach(string file in files)
            {
                existingFileNames.Add(Path.GetFileNameWithoutExtension(file));
            }
            return existingFileNames;
        }

        public static string GenerateRandomName()
        {
            string name = "";
            Random random = new Random();
            for(int i = 0; i < 25; i++)
            {
                if(random.Next(2) == 1)
                {
                    name += (char)random.Next(65, 90);
                }else
                {
                    name += (char)random.Next(97, 122);
                }
            }
            return name;
        }
    }
}

namespace System.IO
{
    public static class ExtendedMethod
    {
        public static void Rename(this FileInfo fileInfo, string newName)
        {
            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
        }
    }
}