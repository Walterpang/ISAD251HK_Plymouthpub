using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PubNew.Models
{
    public class Item
    {
        public Item()
        {
            //isAvailable = true;
        }

        public int ItemID { get; set; }

        [DisplayName("Food name")]
        public String ItemName { get; set; }

        public String Description { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Category")]
        public String Category { get; set; }

        public String ItemPictureUrl { get; set; }

        public bool isAvailable { get; set; }

        public String ItemArt { get; set; }

        public byte[] InternalImage { set; get; }

        public virtual List<OrderItem> OrderItem { get; set; }
    }
}