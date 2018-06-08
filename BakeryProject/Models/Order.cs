using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BakeryProject.Models;


namespace BakeryProject.Models
{
    public class Order
    {

        List<Item> items;
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }

        public decimal Total { set; get; }
        public decimal SubTotalAfterDiscount { set; get; }


        public decimal Discount { set; get; }


        public Order()
        {

            items = new List<Item>();
        }

        public void AddItem(Item i)
        {

            items.Add(i);
        }

        public List<Item> GetItems()
        {

            return items;
        }

        public void CalculateSubTotal()
        {

            decimal sum = 0;

            foreach (Item i in items)
            {
                sum += i.Price * i.Quantity;

            }
            SubTotal = sum;
        }

        public void CalculateDiscount()
        {

            decimal discount = 0;
            foreach (Item i in items)
            {
                discount += i.Price * i.Quantity * i.Discount;
            }
            Discount = discount;
        }

        public void CalculateSubAfterDiscount()
        {

            SubTotalAfterDiscount = SubTotal - Discount;
        }
        public void CalculateTax()
        {

            decimal tax = 0M;
            tax = SubTotal * .09M;
            Tax = tax;

        }

        public void CalculateTotal()
        {

            Total = SubTotalAfterDiscount + Tax;
        }
    }
}