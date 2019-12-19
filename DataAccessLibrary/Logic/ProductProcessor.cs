using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Logic
{
    public static class ProductProcessor
    {
        public static List<ProductModel> GetProducts()
        {
            var sql = $"select * from dbo.Product;";
            var products = DataAccess.DataAccess.LoadData<ProductModel>(sql);

            return PrepareProducts(products);
        }
        public static ProductModel GetProduct(int id)
        {
            var sql = $"select * from dbo.Product WHERE Id = {id};";

            var product = DataAccess.DataAccess.GetSingleData<ProductModel>(sql);

            //get product images
            GetProductImages(product);
            product.ProductType = ProductTypeProcessor.GetType(product.CategoryID);

            return product;
        }
        public static List<ProductModel> GetProductsByType(int categoryId)
        {
            var sql = $"select * from dbo.product where CategoryID = {categoryId}";
            var products = DataAccess.DataAccess.LoadData<ProductModel>(sql);

            return PrepareProducts(products);
        }
        public static List<ProductModel> GetProductsByUser(int userID)
        {
            var sql = $"select * from dbo.Product WHERE UserID = {userID};";
            var products = DataAccess.DataAccess.LoadData<ProductModel>(sql);

            return PrepareProducts(products);
        }
        private static List<ProductModel> PrepareProducts(List<ProductModel> products)
        {
            foreach (ProductModel product in products)
            {
                GetProductImages(product);
                product.ProductType = ProductTypeProcessor.GetType(product.CategoryID);
            }

            return products;
        }
        public static async Task<int> CreateProduct(ProductModel product)
        {
            var sql = @"INSERT INTO dbo.Product (Name, Description,Price, UserID,CategoryID) 
                    VALUES (@Name, @Description, @Price, @UserID, @CategoryID);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

            return DataAccess.DataAccess.SaveData<ProductModel>(sql, product);
        }
        public static ProductModel GetProductImages(ProductModel product)
        {
            product.ProductImages = ImageProcessor.GetProductImages(product.Id);
            return product;
        }
        public static void UpdateProduct(ProductModel product)
        {
            var sql = $@"UPDATE dbo.Product set
                        Name = @Name, Description = @Description, Price = @Price, CategoryID = @CategoryID where Id = {product.Id}";

            DataAccess.DataAccess.UpdateQuery<ProductModel>(sql, product);
        }
    }
}
