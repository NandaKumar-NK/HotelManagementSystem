
using System;
using System.Collections.Generic;
using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;

public partial class HotelBookingDBContext : DbContext
{
    public HotelBookingDBContext()
    {
    }

    public HotelBookingDBContext(DbContextOptions<HotelBookingDBContext> options)
        : base(options)
    {
    }
    public DbSet<BookingDetails> Bookings { get; set; }
    public DbSet<CustomerDetails> CustomerDetails { get; set; }
    public DbSet<HotelDetails> HotelDetails { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<RoomsDetails> RoomsDetails { get; set; }
    public DbSet<User> users { get; set; }

}