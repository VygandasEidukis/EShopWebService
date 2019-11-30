using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Logic
{
    public static class CartProcessor
    {
        public static void CreateCart(UserModel user)
        {
            var sql = $@"if not exists(select * from dbo.Orders where UserID = {user.Id})
                        begin
	                        INSERT INTO dbo.Orders (UserID) values ({@user.Id})
                        end";

            DataAccess.DataAccess.ExecuteQuery(sql);
        }

        public static void AddProductToCart(int product, UserModel user)
        {
            var sql = $@"if exists(select top 1 Id from Orders where UserID = {user.Id} and OrderTypeID = 1)
                        begin
	                        INSERT INTO dbo.OrderProducts (ProductID, OrdersID) 
                            values ({product}, cast((select top 1 Id  from Orders where UserID = {user.Id} and OrderTypeID = 1) as int))
                        end";

            DataAccess.DataAccess.ExecuteQuery(sql);
        }

        public static void RemoveProductFromCart(int product, int user)
        {
            var sql = $@"if exists(select top 1 Id from Orders where UserID = {user} and OrderTypeID = 1)
                        begin
	                        DELETE TOP(1) FROM OrderProducts 
                            WHERE OrderProducts.ProductID = {product} 
                            and OrderProducts.OrdersID = (select top 1 Id from Orders where UserID = {user} and OrderTypeID = 1)
	                        select * from OrderProducts
                        end"; 
            
            DataAccess.DataAccess.ExecuteQuery(sql);
        }

        public static List<ProductModel> GetCartProducts(int userId)
        {
            var sql = $@"if exists(select top 1 Id from Orders where UserID = {userId} and OrderTypeID = 1)
                        begin
	                        select op.ProductID from Orders as o
	                        inner join OrderProducts as op on op.OrdersID = o.Id
	                        where o.OrderTypeID = 1 and o.UserID = {userId}
                        end";

            var productIds = DataAccess.DataAccess.LoadData<int>(sql);
            var products = new List<ProductModel>();
            foreach (var pid in productIds)
                products.Add(ProductProcessor.GetProduct(pid));

            return products;
        }
    }
}
