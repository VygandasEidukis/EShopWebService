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

        public static void AddProductToCart(ProductModel product, UserModel user)
        {
            var sql = $@"if exists(select top 1 Id from Orders where UserID = {user.Id} and OrderTypeID = 1)
                        begin
	                        INSERT INTO dbo.OrderProducts (ProductID, OrdersID) 
                            values ({product.Id}, cast((select top 1 Id  from Orders where UserID = {user.Id} and OrderTypeID = 1) as int))
                        end";

            DataAccess.DataAccess.ExecuteQuery(sql);
        }

        public static void RemoveProductFromCart(ProductModel product, UserModel user)
        {
            var sql = $@"if exists(select top 1 Id from Orders where UserID = {user.Id} and OrderTypeID = 1)
                        begin
	                        DELETE TOP(1) FROM OrderProducts 
                            WHERE OrderProducts.ProductID = {product.Id} 
                            and OrderProducts.OrdersID = (select top 1 Id from Orders where UserID = {user.Id} and OrderTypeID = 1)
	                        select * from OrderProducts
                        end"; 
            
            DataAccess.DataAccess.ExecuteQuery(sql);
        }
    }
}
