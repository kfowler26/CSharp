/*
Author: Kendall Fowler
Date: 11/12/2021
Class: CIS-2255
Description: Practical 4 - Sales Application
*/

namespace CIS_2225_Practical4.BusinessObjects
{
    public class Product
    {
        //Attributes
        private int productID;
        private string description;
        private string retailPrice;
        private string quantity;
        private string markUp;

        //Default Constructor
        public Product()
        {
        }

        //Custom Constructor for Combo Box
        public Product(int id)
        {
            ProductID = id;
        }

        //Public Properties
        public int ProductID { get => productID; set => productID = value; }
        public string Description { get => description; set => description = value; }
        public string RetailPrice { get => retailPrice; set => retailPrice = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string MarkUp { get => markUp; set => markUp = value; }

        //Override toString to display ID
        public override string ToString()
        {
            return "" + ProductID;
        }
    }
}
