// using System;
// using System.Collections.Generic;
// using System.Linq;
// using PizzaStore.Domain.Models;
// using PizzaStore.Domain.Models.PizzaModel;
// using PizzaStore.Domain.Models.ToppingModel;

// namespace PizzaStore.Client
// {
//   class Program
//   {
//     static void Main(string[] args)
//     {
//       Welcome();
//     }
//     static void Welcome()
//     {
//       System.Console.WriteLine("Welcome to PizzaWorld!");
//       System.Console.WriteLine("Best Pizza in the World");
//       System.Console.WriteLine();

//       System.Console.WriteLine("First, choose your role");
//       Starter.UserPerspectiveMenu();
//       int select;
//       int.TryParse(Console.ReadLine(), out select);

//       if (select == 1)
//       {
//         System.Console.WriteLine("Customer Perspective");
//         CustomerRole();
//         System.Console.WriteLine("Thank you, exiting program!");
//       }
//       else if (select == 2)
//       {
//         System.Console.WriteLine("Admin Perspective");
//         // AdminRole();
//       }
//       else
//       {
//         Environment.Exit(0);
//       }

//     }
//     static void AdminRole()
//     {
//       ManageStore.Menu2();
//     }
//     static void CustomerRole()
//     {
//       var starter = new Starter();
//       var user = new User();
//       var store = new Store();

//       ManageStore.Menu(store);

//       do
//       {
//         Starter.OrderMenu();
//         int select;
//         int.TryParse(Console.ReadLine(), out select);

//         if (select == 1)
//         {
//           System.Console.WriteLine("Press Enter to begin your order");
//           Console.ReadLine();
//           AddOrder(starter, user, store);
//         }
//         else if(select == 2)
//         {
//           System.Console.WriteLine("Press Enter to view your order history");
//           Console.ReadLine();
//           ViewOrderHistory(user);
//         }
//         else if(select == 99)
//         {
//           return;
//         }
//       } while (true);
//     }

//     static void ViewOrderHistory(User user)
//     {
//       System.Console.WriteLine("- Your orders");
//       var orders = user.Orders;
//       var counter = 1;
//       foreach(var o in orders)
//       {
//         System.Console.WriteLine($"Order {counter++}:");
//         ManagePizza.DisplayCart3(o);
//         System.Console.WriteLine($"Date and Time: {o.TimeOrdered}");
//       }
//     }
//     static void AddOrder(Starter starter, User user, Store store)
//     {
//       try
//       {
//         ManagePizza.Menu(starter.CreateOrder(user, store));
//       }
//       catch (Exception ex)
//       {
//         System.Console.WriteLine("Whoops, something went wrong!");
//         System.Console.WriteLine(ex.Message);
//       }
//       System.Console.WriteLine("ORDERS: " + user.Orders.Count());
//     }
//   }
// }
