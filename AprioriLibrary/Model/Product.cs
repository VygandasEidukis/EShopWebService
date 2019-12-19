using System.Collections.Generic;

namespace AprioriLibrary.Model
{
    public class Product
    {
        public List<string> itemset = new List<string>();
        public int count = 0;

        public Product()
        {
            itemset = new List<string>();
            count = 0;
        }

        public Product(string itemName)
        {
            itemset = new List<string>();
            count = 0;
            itemset.Add(itemName);
        }
    }
}
