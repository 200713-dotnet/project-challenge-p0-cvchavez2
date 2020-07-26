using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;

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
      var user = new User();
      var store = new Store();

      do
      {
        System.Console.WriteLine("Select from list of options");
        Starter.ManageMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);

        switch (select)
        {
          case 1:
            ManageStore.Menu(store);
            break;
          case 2:
            try
            {
              ManagePizza.Menu(starter.CreateOrder(user, store));
            }
            catch (Exception ex)
            {
              System.Console.WriteLine("Whoops, something went wrong!");
              System.Console.WriteLine(ex.Message);
            }
            System.Console.WriteLine("ORDERS: " + user.Orders.Count());
            break;
          case 3:
            // TODO manage user
            foreach(var o in store.Orders)
            {
              System.Console.WriteLine("order price per store: $" + o.OrderPrice);
            }
            break;
          case 99:
            System.Console.WriteLine("Exiting Pizza Store");
            Environment.Exit(0);
            break;
        }

      } while (true);
    }
  }
}
