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
            cart.CreatePizza("Cheese", "L", "stuffed", new List<Topping> { new Cheese(), new Jalapeno() });
            System.Console.WriteLine("added Cheese Pizza");
            break;
          case 2:
            cart.CreatePizza("pepperoni", "M", "flatbread", new List<Topping> { new Cheese(), new Jalapeno() });
            System.Console.WriteLine("added Pepperoni Pizza");
            break;
          case 3:
            cart.CreatePizza("hawaiian", "XL", "regular", new List<Topping> { new Cheese(), new Jalapeno() });
            System.Console.WriteLine("added Hawaiian Pizza");
            break;
          case 4:
            cart.CreatePizza("custom", "L", "stuffed", new List<Topping> { new Cheese(), new Jalapeno() });
            System.Console.WriteLine("added Custom Pizza");
            break;
          case 5:
            System.Console.WriteLine("Cart\n");
            // TODO check if cart is NOT empty
            if (!IsCartEmpty(cart))
            {
              DisplayCart3(cart);
              CartMenu(cart);
            }
            break;
          case 6:
            // var fileManagerWriter = new FileManager();
            // fileManagerWriter.Write(cart);
            System.Console.WriteLine("exit menu, thank you");
            System.Console.WriteLine(cart.OrderPrice);
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
      if (cart.IsListEmpty())
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
    }
    static void CartMenu(Order cart)
    {
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
      if (cart.IsListEmpty()) // check if cart is empty
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
        EditPizza(cart);
      }
    }
    static void RemovePizza(Order cart)
    {
      System.Console.WriteLine("- Delete a Pizza");
      DisplayCart3(cart);
      Starter.RemovePizzaMenu();

      int select;
      int.TryParse(Console.ReadLine(), out select);
      if (select == 99)
      {
        EditCart(cart);
      }
      cart.RemovePizzaAt(select); // TODO check if there are pizzas to delete
      EditCart(cart);
    }

    static void RemoveAllPizzas(Order cart)
    {
      System.Console.WriteLine("Clearing cart...");
      cart.RemoveAllPizzas();
      System.Console.WriteLine("Success! Cart is empty");
      System.Console.WriteLine("Going Back to Main Menu...");
      System.Console.WriteLine();
      // TODO are you sure you want to delete all
    }

    static void EditPizza(Order cart)
    {
      System.Console.WriteLine("- Edit a Pizza");
      DisplayCart3(cart);
      Starter.EditPizzaMenu();

      int select;
      int.TryParse(Console.ReadLine(), out select);
      if (select == 99)
      {
        EditCart(cart); // going back to menu
      }
      var pizza = cart.Pizzas.ElementAt(select - 1);
      ModifyPizza(pizza);
      DisplayCart3(cart);
      CartMenu(cart);
    }
    static void ModifyPizza(Pizza pizza)
    {
      var exit = false;
      do
      {
        System.Console.WriteLine("- Pizza to modify");
        System.Console.WriteLine(pizza);
        System.Console.WriteLine();
        System.Console.WriteLine("- Modify your Pizza");
        Starter.ModifyPizzaMenu();

        int select;
        int.TryParse(Console.ReadLine(), out select);
        switch (select)
        {
          case 1:
            EditSize(pizza);
            break;
          case 2:
            EditCrust();
            break;
          case 3:
            EditToppings(pizza);
            break;
          case 9:
            System.Console.WriteLine("Awesome! You are done making changes");
            System.Console.WriteLine();
            exit = true;
            break;
        }
      } while (!exit);

    }

    static void EditSize(Pizza pizza)
    {
      System.Console.WriteLine("- Select Pizza Size");
      Starter.SelectPizzaSizeMenu();
      int select;
      int.TryParse(Console.ReadLine(), out select);
      switch (select)
      {
        case 1:
          pizza.EditPizzaSize("S");
          System.Console.WriteLine("Your Pizza is now Small!");
          break;
        case 2:
          pizza.EditPizzaSize("M");
          System.Console.WriteLine("Your Pizza is now Medium!");
          break;
        case 3:
          pizza.EditPizzaSize("L");
          System.Console.WriteLine("Your Pizza is now Large!");
          break;
        case 4:
          pizza.EditPizzaSize("XL");
          System.Console.WriteLine("Your Pizza is now Extra Large!");
          break;
        case 99:
          System.Console.WriteLine("Returning to Modify Pizza Menu...");
          System.Console.WriteLine();
          // ModifyPizza(pizza);
          break;
        default:
          System.Console.WriteLine("Default case");
          System.Console.WriteLine("Returning to Modify Pizza Menu...");
          break;
      }
      pizza.ComputePizzaPrice(); // not sure if call this within Pizza class after changes or here
    }
    static void EditCrust()
    {
      // same logic as editpizza
    }
    static void EditToppings(Pizza pizza)
    {
      var exit = false;
      do
      {
        System.Console.WriteLine("- Toppings ");
        Starter.ToppingsMenu();
        // you have so and so toppings 
        int select;
        int.TryParse(Console.ReadLine(), out select);

        switch (select)
        {
          case 1:
            AddTopping(pizza);
            break;
          case 2:
            RemoveTopping(pizza);
            break;
          case 99:
            exit = true;
            System.Console.WriteLine("You are done!");
            System.Console.WriteLine("Going back to Pizza Menu");
            break;
        }
      } while (!exit);
    }
    static void AddTopping(Pizza pizza)
    {
      var exit = false;
      do
      {
        System.Console.WriteLine($"- Choose your toppings ({pizza.ToppingsCount()}/5) Max. 5");
        Starter.ToppingsListMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);

        if (!pizza.IsToppingsAtRange())
        {
          System.Console.WriteLine("You have exceeded allowed amount of Toppings");
          System.Console.WriteLine("Going back to Toppings Menu...");
          return;
        }

        switch (select)
        {
          case 1:
            pizza.AddPizzaTopping(new Cheese());
            break;
          case 2:
            pizza.AddPizzaTopping(new Cheese()); // change to ham
            break;
          case 3:
            pizza.AddPizzaTopping(new Jalapeno()); // change to jalapeno
            break;
          case 4:
            pizza.AddPizzaTopping(new Cheese()); // change to musshrooms
            break;
          case 5:
            pizza.AddPizzaTopping(new Cheese()); // change to olives
            break;
          case 6:
            pizza.AddPizzaTopping(new Cheese()); // change to pepperoni
            break;
          case 7:
            pizza.AddPizzaTopping(new Cheese()); // change to pineapple
            break;
          case 99:
            exit = true;
            // System.Console.WriteLine("You are done adding toppings");
            System.Console.WriteLine("Going back to Pizza Menu");
            ModifyPizza(pizza);  // probably should not be here
            break;
        }
      } while (!exit);
    }
    static void RemoveTopping(Pizza pizza)
    {
      // TODO method should work when user does not want default toppings
      // and user wants to change a topping
    }
  }
}
