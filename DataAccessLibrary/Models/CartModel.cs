using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public class CartModel
    {
        public List<ProductModel> Products { get; set; }

        public CartModel()
        {
            Products = new List<ProductModel>();
        }
    }
}
