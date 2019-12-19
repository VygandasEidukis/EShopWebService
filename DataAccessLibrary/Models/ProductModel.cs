using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public ProductType ProductType { get; set; }
        public List<ImageModel> ProductImages { get; set; }

        public double ClassificationValue { get; set; }

    }
}
