using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int OrdersID { get; set; }
    }
}
