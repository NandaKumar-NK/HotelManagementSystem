using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class RoomsDetails
    {
        [Key]
        public int RoomNo { get; set; }

        public HotelDetails? HotleId { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public Boolean RoomAvailability { get; set; }
        public DateTime Date {  get; set; }
        public int Price { get; set; }
        public ICollection<BookingDetails> Bookings { get; set; } = new List<BookingDetails>();


    }
}
