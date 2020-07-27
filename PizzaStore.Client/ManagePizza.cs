using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;

namespace PizzaStore.Client
{
  public class ManagePizza
  {
    public ManagePizza()
    { }
    public static void Menu(Order cart)
    {
      var exit = false;
      do
      {
        Starter.PrintMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);
        switch (select)
        {
          case 1:
              AddPizza(cart, new CheesePizzaFactory());
            break;
          case 2:
              AddPizza(cart, new PepperoniPizzaFactory());
            break;
          case 3:
              AddPizza(cart, new HawaiianPizzaFactory());
            break;
          case 4:
              AddPizza(cart, new CustomPizzaFactory());
            break;
          case 5:
            System.Console.WriteLine("Cart\n");
            if (!IsCartEmpty(cart))
            {
              DisplayCart3(cart);
              CartMenu(cart);
            }
            break;
          case 6:
            System.Console.WriteLine("Order TOTAL: " + cart.OrderPrice);
            cart.SetOrderDateTime();
            System.Console.WriteLine("Order submitted at: " + cart.TimeOrdered);
            System.Console.WriteLine("exit menu, thank you");
            exit = true;
            break;
          case 7:
            System.Console.WriteLine("Read File");
            break;
        }
        System.Console.WriteLine();
      } while (!exit);
    }
    static void AddPizza(Order cart, Pizza pizza)
    {
      System.Console.WriteLine("adding Pizza....");
      AdjustPizza(pizza);
      if (!cart.CreatePizza(pizza))
        System.Console.WriteLine("Pizza not added to cart");
    }
    static void AdjustPizza(Pizza pizza)
    {
      System.Console.WriteLine();
      System.Console.WriteLine("This is your Pizza, adjust as needed");
      System.Console.WriteLine("_____________________");
      System.Console.WriteLine(pizza);
      System.Console.WriteLine("_____________________");
      EditSize(pizza);
      System.Console.WriteLine();
      System.Console.WriteLine("_____________________");
      EditToppings(pizza);
      System.Console.WriteLine("_____________________");
      EditCrust(pizza);
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
    public static void DisplayCart3(Order cart)
    {
      int counter = 1;
      foreach (var pizza in cart.Pizzas)
      {
        System.Console.WriteLine(counter++ + ". " + pizza);
        System.Console.WriteLine();
      }
      System.Console.WriteLine($"TOTAL: ${cart.OrderPrice}");
      System.Console.WriteLine();
    }
    static void DisplayToppings(Pizza pizza)
    {
      int counter = 1;
      foreach (var t in pizza.Toppings)
      {
        System.Console.WriteLine(counter++ + ". " + t);
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
            EditCrust(pizza);
            break;
          case 3:
            EditToppings(pizza);
            break;
          case 99:
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
          System.Console.WriteLine("Returning to Modify Pizza Menu..."); //////////////
          System.Console.WriteLine();
          // ModifyPizza(pizza);
          break;
        default:
          System.Console.WriteLine("Default case");
          System.Console.WriteLine("Returning to Modify Pizza Menu..."); //////////////
          break;
      }
    }
    static void EditCrust(Pizza pizza)
    {
      // same logic as editpizza
      System.Console.WriteLine("- Select Crust");
      Starter.EditCrustMenu();
      int select;
      int.TryParse(Console.ReadLine(), out select);

      if(select == 1){
        pizza.EditPizzaCrust("stuffed");
      }
      else if(select == 2){
        pizza.EditPizzaCrust("flatbread");
      }
      else if(select == 99)
      {
        System.Console.WriteLine("Returning to Pizza Menu");
        return;
      }
      else{
        return;
      }

    }
    static void EditToppings(Pizza pizza)
    {
      var exit = false;
      do
      {
        System.Console.WriteLine("- Toppings ");
        System.Console.WriteLine("Your toppings: ");
        DisplayToppings(pizza);
        System.Console.WriteLine();
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
            pizza.AddPizzaTopping(new Ham()); // change to ham
            break;
          case 3:
            pizza.AddPizzaTopping(new Jalapeno()); // change to jalapeno
            break;
          case 4:
            pizza.AddPizzaTopping(new Mushrooms()); // change to musshrooms
            break;
          case 5:
            pizza.AddPizzaTopping(new Olives()); // change to olives
            break;
          case 6:
            pizza.AddPizzaTopping(new Pepperoni()); // change to pepperoni
            break;
          case 7:
            pizza.AddPizzaTopping(new Pineapple()); // change to pineapple
            break;
          case 99:
            exit = true;
            // System.Console.WriteLine("You are done adding toppings");
            System.Console.WriteLine("Going back to Pizza Menu");
            // ModifyPizza(pizza);  // probably should not be here
            break;
        }
      } while (!exit);
    }
    static void RemoveTopping(Pizza pizza)
    {
      // TODO method should work when user does not want default toppings
      // and user wants to change a topping
      var exit = false;
      do
      {
        System.Console.WriteLine("- Your Toppings");
        DisplayToppings(pizza);
        System.Console.WriteLine("- Remove Topping");
        Starter.RemoveToppingMenu();
        int select;
        int.TryParse(Console.ReadLine(), out select);
        if (select == 99)
        {
          exit = true;
          System.Console.WriteLine("Going back to Pizza Menu...");
          return;
        }
        pizza.RemoveTopping(select);
        System.Console.WriteLine("Topping has been removed");
      } while (!exit);
    }
  }
}