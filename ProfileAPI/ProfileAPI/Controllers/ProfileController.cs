using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileAPI.Models;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly pharmvcContext db;
        public ProfileController(pharmvcContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ViewProfile(int id)
        {
            CustomerDetail c = await db.CustomerDetails.FindAsync(id);
            return Ok(c);
        }
        [HttpPut]
        public async Task<IActionResult> EditProfile(int id, CustomerDetail c)
        {
            db.Entry(c).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
