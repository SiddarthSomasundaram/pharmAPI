using System;
using System.Collections.Generic;

#nullable disable

namespace JWTAPI.Models
{
    public partial class ProductDetail
    {
        public int Productid { get; set; }
        public string ProductImage { get; set; }
        public string Productname { get; set; }
        public string ProductDesc { get; set; }
        public float Price { get; set; }
    }
}
