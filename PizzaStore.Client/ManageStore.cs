using System;
using PizzaStore.Domain.Models;
using PizzaStore.Storing.Repositories;

namespace PizzaStore.Client
{
  public class ManageStore
  {
    public ManageStore()
    { }

    public static void Menu2()
    {
      do
      {
        System.Console.WriteLine("Select store to manage");
        StoreStarter.StoreMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);

        if (select == 1)
        {
          System.Console.WriteLine("You selected West store");
          return;
        }
        else if (select == 2)
        {
          System.Console.WriteLine("You selected East store");
          return;
        }
        else if (select == 3)
        {
          System.Console.WriteLine("- List of pizza orders...");
          var repo = new PizzaRepository();
          int counter = 1;
          foreach (var o in repo.ReadAllPizzaOrders())
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
          System.Console.WriteLine();
        }
        else if (select == 99)
        {
          System.Console.WriteLine("Exiting....");
          return;
        }
        else
        {
          System.Console.WriteLine("No store selected...");
        }
      } while (true);
    }
    public static void ManageStoreMenu()
    {
      System.Console.WriteLine("- Store Options");
      int select;
      int.TryParse(Console.ReadLine(), out select);

      if (select == 1)
      {
        System.Console.WriteLine("- View Store Order History");
        OrderHistory();
      }
      else if (select == 2)
      {
        System.Console.WriteLine("- View Store Sales History");
      }
      else if (select == 99)
      {
        System.Console.WriteLine("Exiting Menu....");
        return;
      }
      else
      {
        return;
      }
    }
    public static void OrderHistory()
    {
      System.Console.WriteLine("- Select action");
      StoreStarter.OrderHistoryMenu();
      int select;
      int.TryParse(Console.ReadLine(), out select);

      if (select == 1)
      {
        System.Console.WriteLine("View all Store Orders");
        ViewStoreOrders();
      }
      else if (select == 2)
      {
        System.Console.WriteLine("View Orders by User");
        ViewOrdersByUser();
      }
      else if (select == 99)
      {
        System.Console.WriteLine("Exiting Menu....");
        return;
      }
    }
    public static void ViewStoreOrders()
    {
      // make database connection here to retrieve all orders
      // filtered by store
      var store = new Store();
      var ordersList = store.Orders;
    }
    public static void ViewOrdersByUser()
    {
      // TODO make database connection to retrieve orders based on user
      // if sales see pizza type, count, revenue by week or by month
    }
    public static void Menu(Store store)
    {
      do
      {
        System.Console.WriteLine("Select store to start buying");
        StoreStarter.StoreMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);

        if (select == 1)
        {
          store.Name = "West";
          System.Console.WriteLine("You selected West store");
          return;
        }
        else if (select == 2)
        {
          store.Name = "East";
          System.Console.WriteLine("You selected East store");
          return;
        }
        else if (select == 99)
        {
          System.Console.WriteLine("Exiting....");
          return;
        }
        else
        {
          System.Console.WriteLine("No store selected...");
        }
      } while (true);
    }
  }
}