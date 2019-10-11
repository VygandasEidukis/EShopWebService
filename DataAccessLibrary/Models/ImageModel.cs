using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    class ImageModel
    {
        public int? Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public int? ProductID { get; set; }
    }
}
