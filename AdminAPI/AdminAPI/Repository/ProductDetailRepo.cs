using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Models;

namespace AdminAPI.Repository
{
    public class ProductDetailRepo:IProductDetailRepo<ProductDetail>
    {
        private readonly IProductDetail<ProductDetail> obj;
        public ProductDetailRepo(IProductDetail<ProductDetail> _obj)
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
