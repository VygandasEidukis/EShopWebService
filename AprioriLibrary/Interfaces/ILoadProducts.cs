using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprioriLibrary.Model;

namespace AprioriLibrary.Interfaces
{
    public interface ILoadProducts
    {
        List<Product> LoadProducts(List<List<int>> allProducts);
    }
}
