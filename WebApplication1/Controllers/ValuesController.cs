using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]  // modifies the address for this specific controller
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues() // made async meaning it don't block the thread when someone makes a request. Imagine 100 people trying to access at one while waiting for a response
        {
            var values = await _context.Values.ToListAsync();  // await built in functionality however tolist async is a part of entity framework

            return Ok(values);
        }

        // GET values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
