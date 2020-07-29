// using System.Collections.Generic;
// using PizzaStore.Domain.Models;
// using PizzaStore.Domain.Models.PizzaModel;
// using PizzaStore.Domain.Models.ToppingModel;
// using PizzaStore.Storing.Repositories;

// namespace PizzaStore.Client
// {
//   public class Runner
//   {
//     static void Main(string[] args)
//     {
//       // var starter = new Starter();
//       // var user = new User();
//       // user.Name = "cvchavez2";
//       // var store = new Store();
//       // store.Name = "west";
//       // var order = new Order();
//       // order = starter.CreateOrder(user, store);
//       // ManagePizza.Menu(order);

//       // var userRepository = new UserRepository();
//       // userRepository.Create(user);

//       // System.Console.WriteLine("or here");
//       // var pizza = new Pizza(new Name("My Cheese P"),new Size("M"),new Crust("Regular"),new List<Topping>{new Cheese(), new Jalapeno()});
//       // System.Console.WriteLine("here");
//       // var pizza = new CheesePizzaFactory();
//       // repository.Create(pizza);

//       // var repository = new PizzaRepository();
//       // var pizzaList = repository.ReadAll();
//       // foreach(var p in pizzaList)
//       // {
//       //   System.Console.WriteLine(p);
//       //   System.Console.WriteLine();
//       // }

//       var repo = new UserRepository();
//       var orders = repo.ReadPizzaOrdersByUser("cvchavez2");
//       int counter = 1;
//       foreach (var o in orders)
//       {
//         System.Console.WriteLine("Order " + counter++);
//         int i = 1;
//         foreach (var p in o.Pizzas)
//         {
//           System.Console.WriteLine(i++);
//           System.Console.WriteLine(p);
//           System.Console.WriteLine();
//         }
//       }
//     }
//   }
// }