using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PubNew.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderID { get; set; }

        [ScaffoldColumn(false)]
        public String UserID { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Order date")]
        public DateTime CreatDate { get; set; }
        [ScaffoldColumn(false)]
        public String Stauts { get; set; }
        [ScaffoldColumn(false)]
        public decimal TotalPrice { get; set; }


        public virtual User User { get; set; }
        public virtual List<OrderItem> orderitems { get; set; }

        //public decimal TotalPrice() {
        //    decimal TotalPrice = 0 ;

        //    for(int i =0; i< orderitems.Capacity; i++)
        //    {
        //        TotalPrice += orderitems[i].Price();
        //    }

        //    return TotalPrice;
        //}
    }
}