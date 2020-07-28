using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyClassesController : ControllerBase
    {
        private readonly MyAPIContext _context;

        public MyClassesController(MyAPIContext context)
        {
            _context = context;
        }

        // GET: api/MyClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyClass>>> GetMyClass()
        {
            return await _context.MyClass.ToListAsync();
        }

        // GET: api/MyClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyClass>> GetMyClass(int id)
        {
            var myClass = await _context.MyClass.FindAsync(id);

            if (myClass == null)
            {
                return NotFound();
            }

            return myClass;
        }

        // PUT: api/MyClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyClass(int id, MyClass myClass)
        {
            if (id != myClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(myClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyClassExists(id))
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

        // POST: api/MyClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MyClass>> PostMyClass(MyClass myClass)
        {
            _context.MyClass.Add(myClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyClass", new { id = myClass.Id }, myClass);
        }

        // DELETE: api/MyClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyClass>> DeleteMyClass(int id)
        {
            var myClass = await _context.MyClass.FindAsync(id);
            if (myClass == null)
            {
                return NotFound();
            }

            _context.MyClass.Remove(myClass);
            await _context.SaveChangesAsync();

            return myClass;
        }

        private bool MyClassExists(int id)
        {
            return _context.MyClass.Any(e => e.Id == id);
        }
    }
}
