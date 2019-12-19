using System.Collections.Generic;
using AprioriLibrary.Model;

namespace AprioriLibrary.Interfaces
{
    public interface ILoadProducts
    {
        List<Product> LoadProducts(List<List<int>> allProducts);
    }
}
