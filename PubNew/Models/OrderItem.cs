using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubNew.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Item item { get; set; }
        public virtual Order Order { get; set; }



        //public decimal Price() {
        //    return  item.Price * Quantity ;
        //}
    }
}