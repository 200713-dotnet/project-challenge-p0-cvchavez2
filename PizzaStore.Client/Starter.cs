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
      System.Console.WriteLine("Select 3 to edit a Pizza");
      System.Console.WriteLine("Select 4 to Cancel");
      System.Console.WriteLine();
    }

    internal static void RemovePizzaMenu()
    {
      System.Console.WriteLine("Enter Pizza number to delete");
      System.Console.WriteLine("Enter 99 to return");
    }
    internal static void EditPizzaMenu() // give it a more appropriate name
    {
      System.Console.WriteLine("Enter Pizza number to edit");
      System.Console.WriteLine("Enter 99 to return");
      System.Console.WriteLine();
    }

    internal static void ModifyPizzaMenu() // give it a more appropriate name
    {
      System.Console.WriteLine("Select 1 to change size");
      System.Console.WriteLine("Select 2 to change crust");
      System.Console.WriteLine("Select 3 to change toppings");
      System.Console.WriteLine("Select 9 when you are done");
      System.Console.WriteLine("Enter 99 to return");
      System.Console.WriteLine();
      // TODO add option to edit pizza type

    }
    internal static void SelectPizzaSizeMenu()
    {
      System.Console.WriteLine("Select 1 for Small");
      System.Console.WriteLine("Select 2 for Medium");
      System.Console.WriteLine("Select 3 for Large");
      System.Console.WriteLine("Select 4 for XLarge");
      System.Console.WriteLine("Enter 99 to return");
      System.Console.WriteLine();
    }

    internal static void ToppingsMenu()
    {
      System.Console.WriteLine("Enter 1 to add a topping (Max. 5 Toppings)");
      System.Console.WriteLine("Enter 2 to remove a topping");
      System.Console.WriteLine("Enter 99 if you are done");
    }

    internal static void ToppingsListMenu()
    {
      System.Console.WriteLine("Enter 1 to add Cheese");
      System.Console.WriteLine("Enter 2 to add Ham");
      System.Console.WriteLine("Enter 3 to add Jalapeno");
      System.Console.WriteLine("Enter 4 to add Mushrooms");
      System.Console.WriteLine("Enter 5 to add Olives");
      System.Console.WriteLine("Enter 6 to add Pepperoni");
      System.Console.WriteLine("Enter 7 to add Pineapple");
      System.Console.WriteLine("Enter 99 to return");
    }
  }
}