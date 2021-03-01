using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Consultant_Booking_MVC.Models
{
    //Consultant details
    public class Consultant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int AgencyId { get; set; }

        public Agency Agency { get; set; }
    }
}