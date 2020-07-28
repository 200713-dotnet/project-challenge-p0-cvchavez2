using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Name
    {
        public Name()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int NameId { get; set; }
        public string Name1 { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
