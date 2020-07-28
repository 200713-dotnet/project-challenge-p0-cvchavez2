// using System.Collections.Generic;
// using PizzaStore.Domain.Models;
// using PizzaStore.Domain.Models.PizzaModel;
// using PizzaStore.Domain.Models.ToppingModel;
// using PizzaStore.Storing.Repositories;

// namespace PizzaStore.Client
// {
//   public class Runner
//   {
//     static void Main(string [] args)
//     {
//       var repository = new PizzaRepository();
//       // System.Console.WriteLine("or here");
//       // var pizza = new Pizza(new Name("My Cheese P"),new Size("M"),new Crust("Regular"),new List<Topping>{new Cheese(), new Jalapeno()});
//       // System.Console.WriteLine("here");
//       // var pizza = new CheesePizzaFactory();
//       // repository.Create(pizza);
//       var pizzaList = repository.ReadAll();
//       foreach(var p in pizzaList)
//       {
//         System.Console.WriteLine(p);
//         System.Console.WriteLine();
//       }
//     }
//   }
// }