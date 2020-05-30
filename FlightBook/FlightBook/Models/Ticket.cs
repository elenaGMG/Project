using System;
using System.Collections.Generic;

namespace FlightBook.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string DestinationCity { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
