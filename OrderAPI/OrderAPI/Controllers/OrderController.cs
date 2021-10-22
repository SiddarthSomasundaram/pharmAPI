using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly pharmvcContext db;
        public OrderController(pharmvcContext _db)
        {
            db = _db;
        }
        public static List<AddtoCart> atc = new List<AddtoCart>();
        
        [HttpGet]
        [Route("GetCartByUserId")]
        public async Task<IActionResult> GetCartByUserId(int Userid)
        {
            List<OrderFinal> a = new List<OrderFinal>();
            a = (from i in db.OrderFinals
                 where i.Userid == Userid
                 select i).ToList();
            return Ok(a);
        }
        [HttpDelete]
        [Route("DeleteCartByUserId")]
        public async Task<IActionResult> DeleteCartByUserId(int Userid)
        {
            List<OrderFinal> a = new List<OrderFinal>();
            a = (from i in db.OrderFinals
                 where i.Userid == Userid
                 select i).ToList();
            foreach (OrderFinal item in a)
            {
                db.OrderFinals.Remove(item);
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpGet]
        [Route("OrderCart")]

        public async Task<IActionResult> OrderCart()
        {
            return Ok(await db.OrderFinals.ToListAsync());
        }
        [HttpPost]
        [Route("OrderFinalCart")]
        public async Task<IActionResult> OrderCart(OrderFinal ac)
        {
            db.OrderFinals.Add(ac);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpPost]
        [Route("Paymentorder")]
        public async Task<IActionResult> Paymentsuccess(int id)
        {
            
            //List<AddtoCart> o = new List<AddtoCart>();
            
            foreach (var item in db.AddtoCarts)
            {
                OrderFinal ord = new OrderFinal();
                ord.Userid = id;
                ord.Productid = item.Productid;
                ord.ProductImage = item.ProductImage;
                ord.Productname = item.Productname;
                ord.ProductDesc = item.ProductDesc;
                ord.Price = item.Price;
                db.OrderFinals.Add(ord);
                
            }
            await db.SaveChangesAsync();
            List<AddtoCart> a = new List<AddtoCart>();
            a = (from i in db.AddtoCarts
                 where i.Userid == id
                 select i).ToList();
            foreach (AddtoCart item in a)
            {
                db.AddtoCarts.Remove(item);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
