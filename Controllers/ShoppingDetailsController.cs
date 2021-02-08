using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingDetailsController : ControllerBase
    {
        private readonly ShoppingCartContext _context;

        public ShoppingDetailsController(ShoppingCartContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingDetail>>> GetShoppingDetails()
        {
            return await _context.ShoppingDetails
                .Include(p => p.Category)
                .Include(c => c.Carts)
                .ToListAsync();
        }

        // GET: api/ShoppingDetails/5
        [HttpGet("{id}")]
        public ShoppingDetail GetProduct(int id)
        {
            ShoppingDetail result = _context.ShoppingDetails
            .Include(p => p.Category)
            .Include(c => c.Carts)
            .FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                if (result.Category != null)
                {
                    result.Category.ShoppingDetails = null;
                }
                if (result.Carts != null)
                {
                    result.Carts.ShoppingDetail = null;
                }


            }
            return result;
        }

        // PUT: api/ShoppingDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingDetail(int id, ShoppingDetail shoppingDetail)
        {
            if (id != shoppingDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingDetailExists(id))
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

        // POST: api/ShoppingDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingDetail>> PostShoppingDetail(ShoppingDetail shoppingDetail)
        {
            _context.ShoppingDetails.Add(shoppingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingDetail", new { id = shoppingDetail.Id }, shoppingDetail);
        }

        // DELETE: api/ShoppingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingDetail>> DeleteShoppingDetail(int id)
        {
            var shoppingDetail = await _context.ShoppingDetails.FindAsync(id);
            if (shoppingDetail == null)
            {
                return NotFound();
            }

            _context.ShoppingDetails.Remove(shoppingDetail);
            await _context.SaveChangesAsync();

            return shoppingDetail;
        }

        private bool ShoppingDetailExists(int id)
        {
            return _context.ShoppingDetails.Any(e => e.Id == id);
        }
    }
}
