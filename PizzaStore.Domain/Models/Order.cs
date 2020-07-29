using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    double _orderAmount;
    public Order()
    {
      Pizzas = new List<Pizza>();
    }
    public List<Pizza> Pizzas { get; set; }

    public DateTime TimeOrdered { get; set; }

    public double OrderAmount
    {
      get
      {
        ComputeOrderPrice();
        return _orderAmount;
      }
      set{}
    }
    public bool CreatePizza(Pizza factory)
    {
      var pizza = factory;
      if (OrderAmount + pizza.PizzaPrice > 250)
      {
        System.Console.WriteLine("Order exceeded maximum amount allowed per order");
        System.Console.WriteLine($"Current order total: ${OrderAmount}");
        System.Console.WriteLine($"Current pizza price ${pizza.PizzaPrice}");
        System.Console.WriteLine($"Order exceeds by: ${(OrderAmount + pizza.PizzaPrice) - 250}");
        System.Console.WriteLine("Please try again");
        System.Console.WriteLine();
        return false;
      }
      else if (!IsPizzasInRange())
      {
        System.Console.WriteLine("Order exceeded maximum amount of Pizzas allowed per order");
        System.Console.WriteLine();
        return false;
      }
      Pizzas.Add(pizza);
      // System.Console.WriteLine("Pizza added succesfully to cart");
      return true;
    }

    public void SetOrderDateTime()
    {
      TimeOrdered = DateTime.Now;
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
      _orderAmount = Pizzas.Sum(Pizza => Pizza.PizzaPrice);
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