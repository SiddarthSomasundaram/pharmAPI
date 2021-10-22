using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly pharmvcContext db;
        public ProductController(pharmvcContext _db)
        {
            db = _db;
        }
        [HttpGet]

        public async Task<IActionResult> ItemDetails()
        {
            return Ok(await db.ProductDetails.ToListAsync());
        }
        [HttpGet]
        [Route("GetCart")]

        public async Task<IActionResult> AddtoCart()
        {
            return Ok(await db.AddtoCarts.ToListAsync());
        }
        [HttpPost]

        public async Task<IActionResult> AddtoCart(AddtoCart ac)
        {
            db.AddtoCarts.Add(ac);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("GetCartById")]
        public async Task<ActionResult<AddtoCart>> GetCartById(int id)
        {
            AddtoCart a = await db.AddtoCarts.FindAsync(id);
            return Ok(a);
        }

        [HttpDelete]

        public async Task<IActionResult> DeletefromCart(int id)
        {
            AddtoCart a = await db.AddtoCarts.FindAsync(id);
            db.AddtoCarts.Remove(a);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("GetCartByUserId")]
        public async Task<IActionResult> GetCartByUserId(int Userid)
        {
            List<AddtoCart> a = new List<AddtoCart>();
            a = (from i in db.AddtoCarts
                 where i.Userid == Userid
                 select i).ToList();
            return Ok(a);
        }
        [HttpDelete]
        [Route("DeleteCartByUserId")]
        public async Task<IActionResult> DeleteCartByUserId(int Userid)
        {
            List<AddtoCart> a = new List<AddtoCart>();
            a = (from i in db.AddtoCarts
                 where i.Userid == Userid
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
