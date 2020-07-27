using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Store
  {
    public Store()
    {
      Orders = new List<Order>();
    }

    public List<Order> Orders { get; set; }

    public string Name { get; set; }

  }
}