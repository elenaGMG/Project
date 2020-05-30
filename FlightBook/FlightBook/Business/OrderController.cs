using FlightBook.Data;
using FlightBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBook.Business
{
    class OrderController
    {
        private FlightBookContext context;

        public OrderController()
        {
            this.context = new FlightBookContext();
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order Get(int id)
        {
            return this.context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Order order)
        {
            this.context.Orders.Add(order);
            this.context.SaveChanges();
        }

        public void Update(Order order)
        {
            var orderItem = this.Get(order.Id);
            if (orderItem != null)
            {
                this.context.Entry(orderItem).CurrentValues.SetValues(order);
                this.context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var orderItem = this.Get(id);
            this.context.Orders.Remove(orderItem);
            this.context.SaveChanges();
        }
    }
}
