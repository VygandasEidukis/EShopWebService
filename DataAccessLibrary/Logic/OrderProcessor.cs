using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Logic
{
    public static class OrderProcessor
    {
        public static List<List<int>> GetTransactionProductIdList()
        {
            var transactionProducts = new List<List<int>>();
            var existingOrders = GetTransactionProducts();
            var orders = ExtractUniqueOrders(existingOrders);

            foreach (var order in orders)
            {
                transactionProducts.Add(FindFittingProductsInOrders(existingOrders, order));
            }

            return transactionProducts;
        }

        private static List<OrderProducts> GetTransactionProducts()
        {
            const string sql = "select * from OrderProducts;";
            return DataAccess.DataAccess.LoadData<OrderProducts>(sql);
        }

        private static List<int> FindFittingProductsInOrders(List<OrderProducts> products, int orderID)
        {
            var list = new List<int>();
            foreach (var product in products)
            {
                if(product.OrdersID == orderID)
                    list.Add(product.ProductID);
            }
            return list;
        }

        private static List<int> ExtractUniqueOrders(List<OrderProducts> products)
        {
            var unique = new List<int>();
            foreach (var product in products)
            {
                if(!unique.Contains(product.OrdersID))
                    unique.Add(product.OrdersID);
            }
            return unique;
        }
    }
}
