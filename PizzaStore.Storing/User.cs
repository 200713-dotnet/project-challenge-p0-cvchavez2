using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            UserOrders = new HashSet<UserOrders>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
