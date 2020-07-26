using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    double _orderPrice;
    public Order()
    {
      Pizzas = new List<Pizza>();
    }
    public List<Pizza> Pizzas { get; set; }

    public double OrderPrice
    {
      get
      {
        ComputeOrderPrice();
        return _orderPrice;
      }
    }
    public bool CreatePizza(string name, string size, string crust, List<Topping> toppings)
    {
      var pizza = new Pizza(new Name(name), new Size(size), new Crust(crust), toppings);
      if(OrderPrice + pizza.PizzaPrice > 250){
        System.Console.WriteLine("Order exceeded maximum amount allowed per order");
        System.Console.WriteLine($"Current order total: ${OrderPrice}");
        System.Console.WriteLine($"Current pizza price ${pizza.PizzaPrice}");
        System.Console.WriteLine($"Order exceeds by: ${(OrderPrice+pizza.PizzaPrice)-250}");
        System.Console.WriteLine("Please try again");
        System.Console.WriteLine();
        return false;
      }else if(!IsPizzasInRange()){
        System.Console.WriteLine("Order exceeded maximum amount of Pizzas allowed per order");
        System.Console.WriteLine();
        return false;
      }
      System.Console.WriteLine("Pizza added succesfully to cart");
      Pizzas.Add(pizza);
      return true;
    }

    public int PizzasInOrder()
    {
      return Pizzas.Count();
    }
    public bool IsPizzasInRange()
    {
      return PizzasInOrder() < 50;
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