using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BakeryProject.Models;


namespace BakeryProject.Models
{
    public class Order
    {
        /// <summary>
        /// I created this class to handle the complicated
        /// features of an order. I created the fields to store
        /// the values of the various totals. The MVC forms
        /// won't return the result of a calculation
        /// so I had to create fields to represent them.
        /// The order class contains a list of Item objects.
        /// The Item objects contain the productKey, product name,
        /// product price, quantity and discounts.
        /// The class has 7 methods and a constructor.
        /// The constuctor initializes the List.
        /// AddItem() adds Items to the List.
        /// GetItems() returns the List
        /// Calculate subtotal calculates the totals of
        /// all the items. Calculate Discount gets the total discounts.
        /// Calculate SubtotalAfterDiscounts subtracts the discounts
        /// from the subtotal.
        /// Calculate tax calculates the tax on the sale.
        /// (Although it is in the table I ignored the eat in tax)
        /// The calculate Total method add the subtotal and the tax
        /// </summary>
        /// 
        //fields

        List<Item> items;
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }

        public decimal Total { set; get; }
        public decimal SubTotalAfterDiscount { set; get; }


        public decimal Discount { set; get; }

        //construtor
        public Order()
        {
            //initialize the list object
            items = new List<Item>();
        }

        public void AddItem(Item i)
        {
            //add items to list
            items.Add(i);
        }

        public List<Item> GetItems()
        {
            //get the list
            return items;
        }

        public void CalculateSubTotal()
        {
            //loops through the items
            //to get the subtotal
            decimal sum = 0;

            foreach (Item i in items)
            {
                sum += i.Price * i.Quantity;

            }
            SubTotal = sum;
        }

        public void CalculateDiscount()
        {
            //loops through the items
            //to calculate total discounts
            decimal discount = 0;
            foreach (Item i in items)
            {
                discount += i.Price * i.Quantity * i.Discount;
            }
            Discount = discount;
        }

        public void CalculateSubAfterDiscount()
        {
            //subtracts discounts from subtotal
            SubTotalAfterDiscount = SubTotal - Discount;
        }
        public void CalculateTax()
        {
            //calculates tax
            decimal tax = 0M;
            tax = SubTotal * .09M;
            Tax = tax;

        }

        public void CalculateTotal()
        {
            //calculates the total
            Total = SubTotalAfterDiscount + Tax;
        }
    }
}