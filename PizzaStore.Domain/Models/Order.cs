using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    double _orderPrice;
    public double OrderPrice
    {
      get
      {
        ComputeOrderPrice();
        return _orderPrice;
      }
    }
    public List<Pizza> Pizzas { get; set; }
    public Order()
    {
      Pizzas = new List<Pizza>();
    }
    public void CreatePizza(string name, string size, string crust, List<Topping> toppings)
    {
      Pizzas.Add(new Pizza(new Name(name), new Size(size), new Crust(crust), toppings));
    }

    private void ComputeOrderPrice()
    {
      _orderPrice = Pizzas.Sum(Pizza => Pizza.PizzaPrice);
    }
    public void RemovePizzaAt(int index)
    {
      Pizzas.RemoveAt(index - 1);
    }
    public void RemoveAllPizzas()
    {
      Pizzas.Clear();
    }

    public bool IsListEmpty()
    {
      return Pizzas == null || Pizzas.Count == 0;
    }

  }
}