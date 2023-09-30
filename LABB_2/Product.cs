using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABB_2
{
    internal class Product
    {

        public string ProductName;
        public int CostPerProduct;
        public int NumberOfProduct;
        public int TotalCostProduct;

        public Product(string productName, int costPerProduct, int numberOfProduct, int totalCostProduct)
        {
            ProductName = productName;
            CostPerProduct = costPerProduct;
            NumberOfProduct = numberOfProduct;
            TotalCostProduct = totalCostProduct;

        }

        public override string ToString()
        {
            return string.Format("The product name is : {0}, cost per product is: {1} crowns, number of product/s you want to buy is/are: {2} and the total cost is: {3} crowns", GetProductName(), GetCostPerProduct(), GetNumberOfProduct(), GetTotalCostProduct());


        }

        public string GetProductName()
        {
            return ProductName;
        }
        public int GetCostPerProduct()
        {
            return CostPerProduct;

        }
        public int GetNumberOfProduct()
        {
            return NumberOfProduct;

        }
        public int GetTotalCostProduct()
        {
            return TotalCostProduct;
        }
    }

}

