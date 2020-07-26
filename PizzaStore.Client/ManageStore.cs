using System;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
  public class ManageStore
  {
    public ManageStore()
    { }
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
        else if(select == 99)
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