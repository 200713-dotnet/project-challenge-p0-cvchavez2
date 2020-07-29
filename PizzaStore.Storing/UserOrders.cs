﻿using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class UserOrders
    {
        public int UserOrderId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
