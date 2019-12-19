using System.IO;

namespace DataAccessLibrary.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductID { get; set; }
        public void SaveBytesToImage(byte[] ImageBytes, string NewImagePath)
        {
            using (var ms = new MemoryStream(ImageBytes))
            {
                ms.Seek(0, SeekOrigin.Begin);
                
                using(FileStream fs = new FileStream(NewImagePath, FileMode.OpenOrCreate))
                {
                    ms.CopyTo(fs);
                    fs.Flush();
                }
            }
        }
    }
}
