using FlightBook.Data;
using FlightBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBook.Business
{
   public class UserController
    {
        private FlightBookContext context;

        public UserController()
        {
            this.context = new FlightBookContext();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Get(int id)
        {
            return this.context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void Update(User user)
        {
            var userItem = this.Get(user.Id);
            if (userItem != null)
            {
                this.context.Entry(userItem).CurrentValues.SetValues(user);
                this.context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var userItem = this.Get(id);
            this.context.Users.Remove(userItem);
            this.context.SaveChanges();
        }

    }
}
