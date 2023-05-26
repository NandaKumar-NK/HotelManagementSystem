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
    public class BookingDetailsController : ControllerBase
    {
        private readonly HotelBookingDBContext _context;

        public BookingDetailsController(HotelBookingDBContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetails>>> GetBookings()
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetails>> GetBookingDetails(int id)
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            var bookingDetails = await _context.Bookings.FindAsync(id);

            if (bookingDetails == null)
            {
                return NotFound();
            }

            return bookingDetails;
        }

        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetails(int id, BookingDetails bookingDetails)
        {
            if (id != bookingDetails.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailsExists(id))
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

        // POST: api/BookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingDetails>> PostBookingDetails(BookingDetails bookingDetails)
        {
          if (_context.Bookings == null)
          {
              return Problem("Entity set 'HotelBookingDBContext.Bookings'  is null.");
          }
            _context.Bookings.Add(bookingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingDetails", new { id = bookingDetails.BookingId }, bookingDetails);
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingDetails(int id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var bookingDetails = await _context.Bookings.FindAsync(id);
            if (bookingDetails == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(bookingDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingDetailsExists(int id)
        {
            return (_context.Bookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
