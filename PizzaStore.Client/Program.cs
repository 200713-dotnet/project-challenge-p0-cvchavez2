using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      Welcome();
    }
    static void Welcome()
    {
      System.Console.WriteLine("Welcome to PizzaWorld!");
      System.Console.WriteLine("Best Pizza in the World");
      System.Console.WriteLine();

      var starter = new Starter();
      // var user = new User();
      // var store = new Store();
      try
      {
        Menu(starter.CreateOrder(new User(), new Store()));
      }
      catch (Exception ex)
      {
        System.Console.WriteLine("Whoops, something went wrong!");
        System.Console.WriteLine(ex.Message);
      }
    }
    static void Menu(Order cart)
    {
      var exit = false;
      // var startup = new PizzaStore.Client.Startup();
      do
      {
        Starter.PrintMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);
        switch (select)
        {
          case 1:
            cart.CreatePizza("cheese", "L", "stuffed", new List<string> { "ran", "jal" });
            System.Console.WriteLine("added Cheese Pizza");
            break;
          case 2:
            cart.CreatePizza("pepperoni", "L", "stuffed", new List<string> { "ran", "jal" });
            System.Console.WriteLine("added Pepperoni Pizza");
            break;
          case 3:
            cart.CreatePizza("hawaiian", "L", "stuffed", new List<string> { "ran", "jal" });
            System.Console.WriteLine("added Hawaiian Pizza");
            break;
          case 4:
            cart.CreatePizza("custom", "L", "stuffed", new List<string> { "ran", "jal" });
            System.Console.WriteLine("added Custom Pizza");
            break;
          case 5:
            System.Console.WriteLine("Cart\n");
            // TODO check if cart is NOT empty
            if(!IsCartEmpty(cart))
              DisplayCart3(cart);
            break;
          case 6:
            // var fileManagerWriter = new FileManager();
            // fileManagerWriter.Write(cart);
            System.Console.WriteLine("exit menu, thank you");
            exit = true;
            break;
          case 7:
            System.Console.WriteLine("Read File");
            // var fileManagerReader = new FileManager();
            // DisplayCart3(fileManagerReader.Read());
            break;
        }
        System.Console.WriteLine();
      } while (!exit);
    }

    static bool IsCartEmpty(Order cart)
    {
      if (cart.Pizzas == null || cart.Pizzas.Count == 0)
      {
        System.Console.WriteLine("Cart is empty, nothing to display");
        System.Console.WriteLine("Going back to main menu...");
        System.Console.WriteLine();
        return true;
      }
      return false;
    }
    static void DisplayCart3(Order cart)
    {
      int counter = 1;
      foreach (var pizza in cart.Pizzas)
      {
        System.Console.WriteLine(counter++ + ". " + pizza);
        System.Console.WriteLine();
      }

      Starter.CartMenu();
      int select;
      int.TryParse(Console.ReadLine(), out select);

      if (select == 1)
      {
        EditCart(cart);
      }
    }
    static void EditCart(Order cart)
    {
      System.Console.WriteLine("- Edit Cart");
      if(IsCartEmpty(cart)) // check if cart is empty
        return;
      Starter.EditCartMenu();
      int select;
      int.TryParse(Console.ReadLine(), out select);

      if (select == 1)
      {
        RemovePizza(cart);
      }
      else if (select == 2)
      {
        RemoveAllPizzas(cart);
      }
      else if (select == 3)
      {
        // TODO edit order
      }
    }
    static void RemovePizza(Order cart)
    {
      System.Console.WriteLine("- Delete a Pizza");
      Starter.RemovePizzaMenu();
      int select;
      int.TryParse(Console.ReadLine(), out select);
      if(select == 99)
      {
        EditCart(cart);
      }
      cart.Pizzas.RemoveAt(select-1); // TODO check if there are pizzas to delete
      EditCart(cart);
    }

    static void RemoveAllPizzas(Order cart)
    {
      System.Console.WriteLine("Clearing cart...");
      cart.Pizzas.Clear();
      System.Console.WriteLine("Success! Cart is empty");
      System.Console.WriteLine("Going Back to Main Menu...");
      // TODO are you sure you want to delete all
    }
  }
}
