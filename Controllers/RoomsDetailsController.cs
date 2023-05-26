using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsDetailsController : ControllerBase
    {
        private readonly HotelBookingDBContext _context;

        public RoomsDetailsController(HotelBookingDBContext context)
        {
            _context = context;
        }

        // GET: api/RoomsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomsDetails>>> GetRoomsDetails()
        {
          if (_context.RoomsDetails == null)
          {
              return NotFound();
          }
            return await _context.RoomsDetails.ToListAsync();
        }

        // GET: api/RoomsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomsDetails>> GetRoomsDetails(int id)
        {
          if (_context.RoomsDetails == null)
          {
              return NotFound();
          }
            var roomsDetails = await _context.RoomsDetails.FindAsync(id);

            if (roomsDetails == null)
            {
                return NotFound();
            }

            return roomsDetails;
        }

        // PUT: api/RoomsDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomsDetails(int id, RoomsDetails roomsDetails)
        {
            if (id != roomsDetails.RoomNo)
            {
                return BadRequest();
            }

            _context.Entry(roomsDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsDetailsExists(id))
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

        // POST: api/RoomsDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomsDetails>> PostRoomsDetails(RoomsDetails roomsDetails)
        {
          if (_context.RoomsDetails == null)
          {
              return Problem("Entity set 'HotelBookingDBContext.RoomsDetails'  is null.");
          }
            _context.RoomsDetails.Add(roomsDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomsDetails", new { id = roomsDetails.RoomNo }, roomsDetails);
        }

        // DELETE: api/RoomsDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomsDetails(int id)
        {
            if (_context.RoomsDetails == null)
            {
                return NotFound();
            }
            var roomsDetails = await _context.RoomsDetails.FindAsync(id);
            if (roomsDetails == null)
            {
                return NotFound();
            }

            _context.RoomsDetails.Remove(roomsDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomsDetailsExists(int id)
        {
            return (_context.RoomsDetails?.Any(e => e.RoomNo == id)).GetValueOrDefault();
        }
    }
}
