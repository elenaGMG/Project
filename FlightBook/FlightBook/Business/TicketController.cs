using FlightBook.Data;
using FlightBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBook.Business
{
   public class TicketController
    {
        private FlightBookContext context;

        public TicketController()
        {
            this.context = new FlightBookContext();
        }

        public List<Ticket> GetAll()
        {
            return context.Tickets.ToList();
        }

        public Ticket Get(int id)
        {
            return this.context.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Ticket ticket)
        {
            this.context.Tickets.Add(ticket);
            this.context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            var ticketItem = this.Get(ticket.Id);
            if (ticketItem != null)
            {
                this.context.Entry(ticketItem).CurrentValues.SetValues(ticket);
                this.context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var ticketItem = this.Get(id);
            this.context.Tickets.Remove(ticketItem);
            this.context.SaveChanges();
        }
    }
}
