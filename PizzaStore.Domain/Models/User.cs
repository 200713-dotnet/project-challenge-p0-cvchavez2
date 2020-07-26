using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class User
  {
    public User()
    {
      Orders = new List<Order>();
    }
    public User(string name)
    {
      Orders = new List<Order>();
      Name = name;
    }
    public List<Order> Orders { get; set; }
    public string Name { get; set; } // for now Name will be a string
  }
}