using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly pharmvcContext db;
        public LoginController(pharmvcContext _db)
        {
            db = _db;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(CustomerDetail c)
        {

            var cd = db.CustomerDetails.Where(p => p.Email == c.Email && p.Password == c.Password).FirstOrDefault();
            return Ok(cd);
        }


        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup(CustomerDetail user)
        {
            db.CustomerDetails.Add(user);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
