using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;
using PizzaStore.Storing.Repositories;

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

      System.Console.WriteLine("First, choose your role");
      Starter.UserPerspectiveMenu();
      int select;
      int.TryParse(Console.ReadLine(), out select);

      if (select == 1)
      {
        System.Console.WriteLine("__Customer Perspective__");
        CustomerRole();
        System.Console.WriteLine("Thank you, exiting Pizza Store!");
      }
      else if (select == 2)
      {
        System.Console.WriteLine("__Admin Perspective__");
        AdminRole();
      }
      else
      {
        Environment.Exit(0);
      }

    }
    static void AdminRole()
    {
      ManageStore.Menu2();
    }
    static void CustomerRole()
    {
      System.Console.WriteLine("Do you want to place an order");
      System.Console.WriteLine("or");
      System.Console.WriteLine("view your order history?");
      System.Console.WriteLine();
      var starter = new Starter();
      var user = new User();
      var store = new Store();

      do
      {
        Starter.OrderMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);

        if (select == 1)
        {
          if (user.Name == null)
          {
            System.Console.WriteLine("Please enter a username");
            string name = Console.ReadLine();
            user.Name = name;
          }
          System.Console.WriteLine("Press Enter to begin your order");
          Console.ReadLine();
          AddOrder(starter, user, store);
        }
        else if (select == 2)
        {
          System.Console.WriteLine("Press Enter to view order history");
          Console.ReadLine();
          ViewOrderHistoryByUserId();
        }
        else if (select == 99)
        {
          return;
        }
      } while (true);
    }
    static void ViewOrderHistoryByUserId()
    {
      System.Console.WriteLine("Please enter the name you want to query");
      string name = Console.ReadLine();
      System.Console.WriteLine("- Your orders " + name);
      var repo = new UserRepository();
      int counter = 1;
      foreach (var o in repo.ReadPizzaOrdersByUser(name))
      {
        System.Console.WriteLine("Order " + counter++);
        int i = 1;
        foreach (var p in o.Pizzas)
        {
          System.Console.WriteLine(i++);
          System.Console.WriteLine(p);
          System.Console.WriteLine();
        }
      }
    }
    static void ViewOrderHistory(User user)
    {
      System.Console.WriteLine("- Your orders " + user.Name);
      var orders = user.Orders;
      var counter = 1;
      foreach (var o in orders)
      {
        System.Console.WriteLine($"Order {counter++}:");
        ManagePizza.DisplayCart3(o);
        System.Console.WriteLine($"Date and Time: {o.TimeOrdered}");
        System.Console.WriteLine();
      }
    }
    static void AddOrder(Starter starter, User user, Store store)
    {
      var order = new Order();
      try
      {
        order = starter.CreateOrder(user, store);
        ManagePizza.Menu(order);
        var userRepository = new UserRepository();
        userRepository.Create(user);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine("Whoops, something went wrong!");
        System.Console.WriteLine(ex.Message);
      }
      System.Console.WriteLine("ORDERS: " + user.Orders.Count());
      System.Console.WriteLine();
    }
  }
}
