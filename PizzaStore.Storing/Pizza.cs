using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int PizzaId { get; set; }
        public string Name { get; set; }
        public int? NameId { get; set; }
        public int CrustId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Name NameNavigation { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
