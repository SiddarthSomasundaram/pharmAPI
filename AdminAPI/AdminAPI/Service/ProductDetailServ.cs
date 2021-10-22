using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Models;
using AdminAPI.Repository;
using AdminAPI.Service;


namespace AdminAPI.Service
{
    public class ProductDetailServ:IProductDetailServ<ProductDetail>
    {
        private readonly IProductDetailRepo<ProductDetail> obj;
        public ProductDetailServ(IProductDetailRepo<ProductDetail> _obj)
        {
            obj = _obj;
        }

        public void AddItem(ProductDetail i)
        {
            obj.AddItem(i);
        }

        public void DeleteItem(int id)
        {
            obj.DeleteItem(id);
        }

        public List<ProductDetail> GetAllItem()
        {
            return obj.GetAllItem();
        }

        public ProductDetail GetItemById(int id)
        {
            return obj.GetItemById(id);
        }

        public void UpdateItem(int id, ProductDetail i)
        {
            obj.UpdateItem(id, i);
        }
    }
}
