using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprioriLibrary.Data;
using AprioriLibrary.Interfaces;
using AprioriLibrary.Model;

namespace AprioriLibrary.Apriori
{
    public class Apriori
    {
        public float MinSupport { get; set; }
        public float MinConfidence { get; set; }
        public int TransactionAmount { get; set; }
        public List<Product> InitialProducts { get; set; }
        public List<List<int>> InitialStaticList { get; set; }

        public  List<Product> candidateGen(List<Product> supportedItems)
        {
            int subset = supportedItems[0].itemset.Count;

            List<Product> initialItems = new List<Product>();

            bool canCreate = true;
            int len = supportedItems[0].itemset.Count - 1;

            for (int i = 0; i < supportedItems.Count; i++)
            {
                for (int j = i + 1; j < supportedItems.Count; j++)
                {
                    if (!supportedItems[i].itemset[len].Equals(supportedItems[j].itemset[len]))
                    {
                        if (subset > 1)
                        {
                            for (int iF = 0; iF < len; iF++)
                            {
                                if (!supportedItems[i].itemset[iF].Equals(supportedItems[j].itemset[iF]))
                                {
                                    canCreate = false;
                                    break;
                                }
                                canCreate = true;
                            }
                        }

                        if (canCreate)
                        {
                            Product c = new Product();
                            c.itemset.AddRange(supportedItems[i].itemset.GetRange(0, supportedItems[i].itemset.Count));
                            c.itemset.Add(supportedItems[j].itemset[len]);
                            c.count = 0;
                            initialItems.Add(c);
                            bool isRemove = true;
                            for (int ic = 0; ic < c.itemset.Count; ic++)
                            {
                                Product t = new Product();
                                t.itemset = c.itemset.GetRange(0, c.itemset.Count);
                                t.itemset.RemoveAt(ic);

                                for (int iF1 = 0; iF1 < supportedItems.Count; iF1++)
                                {
                                    for (int ii = 0; ii < supportedItems[iF1].itemset.Count; ii++)
                                    {
                                        for (int jj = 0; jj < t.itemset.Count; jj++)
                                        {
                                            if (!supportedItems[iF1].itemset[ii].Equals(t.itemset[jj]))
                                            {
                                                break;
                                            }
                                            isRemove = false;
                                        }
                                    }
                                }
                            }
                            if (isRemove)
                            {
                                initialItems.Remove(c);
                            }
                        }
                    }
                }
            }
            return initialItems;
        }

        public List<Product> ExtractSupportedProducts(List<Product> productList)
        {
            List<Product> supportedItems = productList;
            int index = 0;
            while (index < supportedItems.Count)
            {
                if ((float)supportedItems[index].count / TransactionAmount < MinSupport)
                {
                    supportedItems.RemoveAt(index);
                }
                else
                {
                    index++;
                }
            }
            return supportedItems;
        }

        public  void ap_genRules(List<Product> FRoot, Product temporarySupportedItems, List<Product> H, int iteration, int m, float minConfidence)
        {
            List<Product> Hm = new List<Product>();
            if ((iteration > m + 1) && (H.Count > 0))
            {
                Hm = candidateGen(H);
                int i = 0;
                while (i < Hm.Count)
                {
                    Product F_b = Hm[i];
                    Product F_a = new Product();
                    for (int z = 0; z < temporarySupportedItems.itemset.Count; z++)
                    {
                        for (int x = 0; x < F_b.itemset.Count; x++)
                        {
                            if (temporarySupportedItems.itemset[z] == F_b.itemset[x])
                            {
                                break;
                            }
                            if (x == F_b.itemset.Count - 1)
                            {
                                F_a.itemset.Add(temporarySupportedItems.itemset[z]);
                            }
                        }
                    }
                    float conf = (float)temporarySupportedItems.count / getItemCount(FRoot, F_a);
                    if (conf >= minConfidence)
                    {
                        writeARFile("./../../AR.txt", F_a, F_b, conf, true);
                        i++;
                    }
                    else
                    {
                        Hm.RemoveAt(i);
                    }
                }
                ap_genRules(FRoot, temporarySupportedItems, Hm, iteration, m + 1, minConfidence);
            }
        }

        public  int getItemCount(List<Product> FRoot, Product Product)
        {
            if (FRoot == null || Product == null)
                throw new Exception();

            for (int i = 0; i < FRoot.Count; i++)
            {
                if (FRoot[i].itemset.Count == Product.itemset.Count)
                {
                    if (is2ItemEquals(FRoot[i], Product))
                    {
                        return FRoot[i].count;
                    }
                }
            }
            return -1;
        }

        public  bool is2ItemEquals(Product item1, Product item2)
        {
            if (item1 == null || item2 == null)
                throw new Exception("No item set");

            for (int i = 0; i < item2.itemset.Count; i++)
            {
                if (!(item1.itemset[i] == item2.itemset[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public  void writeARFile(string filePath, Product F_a, Product F_b, float conf, bool isAppend)
        {
            using (StreamWriter writetext = new StreamWriter(filePath, isAppend))
            {
                writetext.Write(conf.ToString("0.00") + " ");
                for (int a = 0; a < F_a.itemset.Count; a++)
                {
                    writetext.Write("{0}", F_a.itemset[a]);
                    if (a < F_a.itemset.Count - 1)
                    {
                        writetext.Write(",");
                    }
                }
                writetext.Write("-> ");
                for (int b = 0; b < F_b.itemset.Count; b++)
                {
                    writetext.Write("{0}", F_b.itemset[b]);
                    if (b < F_b.itemset.Count - 1)
                    {
                        writetext.Write(",");
                    }
                }
                writetext.WriteLine("");
            }
        }


        public List<Product> LoadFromProductTransactionList(List<List<int>> transactionList)
        {
            ILoadProducts productLoader = new LoadProductsById();
            return productLoader.LoadProducts(transactionList);
        }

        public Apriori(List<List<int>> transactions, float minSupport, float minConfidence)
        {
            this.TransactionAmount = transactions.Count();
            this.MinSupport = minSupport;
            this.MinConfidence = minConfidence;
            this.InitialProducts = LoadFromProductTransactionList(transactions);
            this.InitialStaticList = transactions;
        }

        private static int UnanimousExistence(List<int> existenceInts)
        {
            int min = int.MaxValue;
            foreach (var item in existenceInts)
            {
                if (item < min)
                    min = item;
            }
            return min;
        }

        private int FindTransactionRepetition(Product product)
        {
            int repetition = 0;

            //in all transactions
            for (var transactionIndex = 0; transactionIndex < InitialStaticList.Count; transactionIndex++)
            { 
                var productAmount = product.itemset.Count();
                var found = new List<int>();

                //trough all iterations
                for (int iteration = 0; iteration < productAmount; iteration++)
                {
                    found.Add(0);
                    //we check iteration
                    for (int productIndex = 0; productIndex < InitialStaticList[transactionIndex].Count; productIndex++)
                    {
                        //if iteration product exists, we set it to true
                        if (product.itemset[iteration] == InitialStaticList[transactionIndex][productIndex].ToString())
                            found[iteration]++;
                    }
                }

                //if product set exists in 
                repetition += UnanimousExistence(found);
            }
            return repetition;
        }

        public List<int> Calculate()
        {
            var supportedItems = ExtractSupportedProducts(InitialProducts);
            List<Product> temporarySupportedItems = supportedItems;

            if (supportedItems.Count == 0)
            {
                return  new List<int>();
            }
            do
            {
                InitialProducts = candidateGen(temporarySupportedItems);

                for (int i = 1; i < InitialProducts.Count; i++)
                {
                    InitialProducts[i].count = FindTransactionRepetition(InitialProducts[i]);
                }

                temporarySupportedItems = ExtractSupportedProducts(InitialProducts);
                supportedItems.AddRange(temporarySupportedItems);
            } while (temporarySupportedItems.Count > 0);

            if (supportedItems.Count < 1) return new List<int>();

            return ExtractIntsFromProducts(supportedItems[supportedItems.Count - 1]);
        }

        private List<int> ExtractIntsFromProducts (Product product)
        {
            var values = new List<int>();
            foreach (var prod in product.itemset)
            {
                values.Add(int.Parse(prod));
            }

            return values;
        }
    }
}
