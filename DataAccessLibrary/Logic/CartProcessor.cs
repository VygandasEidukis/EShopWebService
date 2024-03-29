﻿using System.Collections.Generic;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Logic
{
    public static class CartProcessor
    {
        public static void BuyProducts(int userId, int cartId)
        {
            var sql = $@"if (select top 1 count(*) from OrderProducts where OrderProducts.OrdersID = {cartId} ) > 0
                        begin
	                        update Orders set OrderTypeID = 2 where Orders.UserID = {userId} and Orders.OrderTypeID = 1
                        end";
            DataAccess.DataAccess.ExecuteQuery(sql);
        }

        public static void CreateCart(UserModel user)
        {
            var sql = $@"if not exists(select * from dbo.Orders where UserID = {user.Id})
                        begin
	                        INSERT INTO dbo.Orders (UserID) values ({@user.Id})
                        end";

            DataAccess.DataAccess.ExecuteQuery(sql);
        }

        public static int GetActiveCartId(int userId)
        {
            var sql = $@"select top 1 * from Orders where UserID = {userId} and OrderTypeID = 1";
            try
            {
                return DataAccess.DataAccess.GetSingleData<int>(sql);
            }
            catch
            {
                return 0;
            }
        }

        public static void AddProductToCart(int product, UserModel user)
        {

            //if in progress cart doesn't exist for user, create it
            //add product to OrderProducts
            var sql = $@"if not exists(select top 1 Id from Orders where UserID = {user.Id} and OrderTypeID = 1)
                        begin
	                        INSERT INTO dbo.Orders (UserID) values ({user.Id})
                        end
                        INSERT INTO dbo.OrderProducts (ProductID, OrdersID) 
                        values ({product}, cast((select top 1 Id  from Orders where UserID = {user.Id} and OrderTypeID = 1) as int))
                        ";

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
            if (productIds.Count <= 0) return products;
            foreach (var pid in productIds)
                products.Add(ProductProcessor.GetProduct(pid));
            return products;
        }
    }
}
