using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryProject.Models
{
    public class Order
    {
        public int ProductKey{ get; set; }
        public string ProductName { get; set; }
        public decimal PricePrice { get; set; }
        public int SaleDetailQuantity { get; set; }
    }
}