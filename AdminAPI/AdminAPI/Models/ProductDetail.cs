using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace AdminAPI.Models
{
    public partial class ProductDetail:IProductDetail<ProductDetail>
    {
        private readonly pharmvcContext db = new pharmvcContext();
        public int Productid { get; set; }
        public string ProductImage { get; set; }
        public string Productname { get; set; }
        public string ProductDesc { get; set; }
        public float Price { get; set; }

        public void AddItem(ProductDetail i)
        {
            db.ProductDetails.Add(i);
            db.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            ProductDetail i = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(i);
            db.SaveChanges();
        }

        public List<ProductDetail> GetAllItem()
        {
            return db.ProductDetails.ToList();
        }

        public ProductDetail GetItemById(int id)
        {
            ProductDetail i = db.ProductDetails.Find(id);
            return i;
        }

        public void UpdateItem(int id, ProductDetail i)
        {
            using(var db=new pharmvcContext())
            {
                db.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }   
        }
    }
}
