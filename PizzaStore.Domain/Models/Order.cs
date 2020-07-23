using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    public Order(){
      Pizzas = new List<Pizza>();
    }
    public List<Pizza> Pizzas { get; set; }

    public void CreatePizza(string name, string size, string crust, List<string> toppings)
    {
      Pizzas.Add(new Pizza(name, size, crust, toppings));
    }
  }
}