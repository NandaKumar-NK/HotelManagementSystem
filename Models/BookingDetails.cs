using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        public CustomerDetails? Customer { get; set; }
        public HotelDetails? Hotel { get; set; }
        public RoomsDetails? Rooms { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get;  set; }
        public double Price { get; set; }
    }
}
