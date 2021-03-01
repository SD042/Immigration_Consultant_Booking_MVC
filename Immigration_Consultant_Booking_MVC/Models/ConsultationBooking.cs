using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Consultant_Booking_MVC.Models
{
    //Consultant booking details
    public class ConsultationBooking
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ConsultantId { get; set; }

        public Consultant Consultant { get; set; }

        public Client Client { get; set; }


    }
}