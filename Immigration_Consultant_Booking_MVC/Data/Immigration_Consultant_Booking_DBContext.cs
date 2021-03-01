using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Immigration_Consultant_Booking_MVC.Models;

namespace Immigration_Consultant_Booking_MVC.Data
{
    public class Immigration_Consultant_Booking_DBContext : DbContext
    {
        public Immigration_Consultant_Booking_DBContext (DbContextOptions<Immigration_Consultant_Booking_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Immigration_Consultant_Booking_MVC.Models.Agency> Agency { get; set; }

        public DbSet<Immigration_Consultant_Booking_MVC.Models.Client> Client { get; set; }

        public DbSet<Immigration_Consultant_Booking_MVC.Models.Consultant> Consultant { get; set; }

        public DbSet<Immigration_Consultant_Booking_MVC.Models.ConsultationBooking> ConsultationBooking { get; set; }
    }
}
