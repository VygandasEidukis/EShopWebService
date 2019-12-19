using System.Collections.Generic;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Logic
{
    public class ProductTypeProcessor
    {
        public static ProductType GetType(int productId)
        {
            var sql = $"select * from ProductType where id = {productId}";
            return DataAccess.DataAccess.GetSingleData<ProductType>(sql);
        }

        public static List<ProductType> GetAllTypes()
        {
            var sql = "select * from ProductType";
            return DataAccess.DataAccess.LoadData<ProductType>(sql);
        }

    }
}
