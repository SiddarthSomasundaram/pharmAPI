using System;
using System.Collections.Generic;

#nullable disable

namespace ProductAPI.Models
{
    public partial class OrderFinal
    {
        public int Orderid { get; set; }
        public int? Userid { get; set; }
        public int? Productid { get; set; }
        public string ProductImage { get; set; }
        public string Productname { get; set; }
        public string ProductDesc { get; set; }
        public float Price { get; set; }
    }
}
