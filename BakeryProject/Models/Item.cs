using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BakeryProject.Models;

namespace BakeryProject.Models
{
    public class Item
    {

        public int ProductKey { set; get; }
        public string ProductName { get; set; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public decimal Discount { set; get; }
    }
}