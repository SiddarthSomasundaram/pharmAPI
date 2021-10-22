using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAPI.Models
{
    public interface IProductDetail<ProductDetail>
    {
        public void AddItem(ProductDetail i);
        public List<ProductDetail> GetAllItem();
        public void UpdateItem(int id, ProductDetail i);
        public void DeleteItem(int id);
        public ProductDetail GetItemById(int id);
    }
}
