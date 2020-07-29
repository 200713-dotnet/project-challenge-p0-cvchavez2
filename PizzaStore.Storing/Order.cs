using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Order
    {
        public Order()
        {
            OrderPizza = new HashSet<OrderPizza>();
            UserOrders = new HashSet<UserOrders>();
        }

        public int OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
