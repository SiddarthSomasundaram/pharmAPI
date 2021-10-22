using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Models;
using AdminAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static List<ProductDetail> obj = new List<ProductDetail>();
        private readonly IProductDetailServ<ProductDetail> serv;
        
        public AdminController(IProductDetailServ<ProductDetail> _serv)
        {
            serv = _serv;
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            obj = serv.GetAllItem();
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDetail p)
        {
            serv.AddItem(p);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditProduct(int id, ProductDetail p)
        {
            //ProductDetail p  =db.ProductDetails.Find(id);
            serv.UpdateItem(id, p);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            serv.DeleteItem(id);
            return Ok();
        }
        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetByProductId(int id)
        {
            ProductDetail obj=new ProductDetail();
            obj = serv.GetItemById(id);
            return Ok(obj);
        }
    }
}
