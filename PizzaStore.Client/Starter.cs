using System;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
  public class Starter
  {
    public Order CreateOrder(User user, Store store)
    {
      // TODO add new order to user and store but why ?????
      try
      {
        // var order = new Order();
        // user.Orders.Add(order);
        // store.Orders.Add(order);        
        return new Order();
      }
      catch
      {
        throw new System.Exception();
      }
      finally
      {
        GC.Collect();
      }
    }
    internal static void PrintMenu()
    {
      System.Console.WriteLine("Select 1 for Cheese Pizza");
      System.Console.WriteLine("Select 2 for Pepperoni Pizza");
      System.Console.WriteLine("Select 3 for Hawaian Pizza");
      System.Console.WriteLine("Select 4 for Custom Pizza");
      System.Console.WriteLine("Select 5 to show Cart");
      System.Console.WriteLine("Select 6 to Exit");
      System.Console.WriteLine("Select 7 to Read File");
      System.Console.WriteLine();
    }
    internal static void CartMenu()
    {
      System.Console.WriteLine("Select 1 to edit cart");
      System.Console.WriteLine("Select 2 to exit cart");
      System.Console.WriteLine();
    }

    internal static void EditCartMenu()
    {
      System.Console.WriteLine("Select 1 to remove a Pizza");
      System.Console.WriteLine("Select 2 to remove All Pizzas and start over");
      System.Console.WriteLine("Select 3 to edit order");
      System.Console.WriteLine("Select 4 to Cancel");
      System.Console.WriteLine();
    }

    internal static void RemovePizzaMenu()
    {
      System.Console.WriteLine("Enter Pizza number to delete");
      System.Console.WriteLine("Enter 99 to return");
    }
  }
}