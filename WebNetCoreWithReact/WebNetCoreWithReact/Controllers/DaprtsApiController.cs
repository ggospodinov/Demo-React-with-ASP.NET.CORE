using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNetCoreWithReact.Data;
using WebNetCoreWithReact.Models;

namespace WebNetCoreWithReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaprtsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DaprtsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DaprtsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Daprt>>> GetDaprts()
        {
            return await _context.Daprts.ToListAsync();
        }

        // GET: api/DaprtsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Daprt>> GetDaprt(int id)
        {
            var daprt = await _context.Daprts.FindAsync(id);

            if (daprt == null)
            {
                return NotFound();
            }

            return daprt;
        }

        // PUT: api/DaprtsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDaprt(int id,[FromForm] Daprt daprt)
        {
            if (id != daprt.DepartNumber)
            {
                return BadRequest();
            }

            _context.Entry(daprt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaprtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DaprtsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Daprt>> PostDaprt([FromForm] Daprt daprt)
        {
            _context.Daprts.Add(daprt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDaprt", new { id = daprt.DepartNumber }, daprt);
        }

        // DELETE: api/DaprtsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Daprt>> DeleteDaprt(int id)
        {
            var daprt = await _context.Daprts.FindAsync(id);
            if (daprt == null)
            {
                return NotFound();
            }

            _context.Daprts.Remove(daprt);
            await _context.SaveChangesAsync();

            return daprt;
        }

        private bool DaprtExists(int id)
        {
            return _context.Daprts.Any(e => e.DepartNumber == id);
        }
    }
}
