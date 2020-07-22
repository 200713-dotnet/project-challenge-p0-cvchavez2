using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    public Order(){
      Pizzas = new List<Pizza>();
    }
    public List<Pizza> Pizzas { get; set; }

  }
}