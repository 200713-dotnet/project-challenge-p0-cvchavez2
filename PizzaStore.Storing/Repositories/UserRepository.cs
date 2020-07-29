using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using domain = PizzaStore.Domain.Models;

namespace PizzaStore.Storing.Repositories
{
  public class UserRepository
  {
    private PizzaStoreDBContext _db = new PizzaStoreDBContext();

    public void Create(domain.User user)
    {
      var newUser = new User();
      newUser.Name = user.Name;

      foreach (var o in user.Orders) // extract orders to store
      {
        var order = new Order() { DateTime = o.TimeOrdered, User = newUser };
        var userOrders = new UserOrders() { Order = order, User = newUser };
        foreach (var p in o.Pizzas)
        {
          var pizza = GetPizza(p);
          order.OrderPizza.Add(new OrderPizza() { Order = order, Pizza = pizza });
        }
        newUser.Order.Add(order);
        newUser.UserOrders.Add(userOrders);
      }
      _db.User.Add(newUser);
      System.Console.WriteLine("Added Successfully!");
      _db.SaveChanges();
    }
    public Pizza GetPizza(domain.PizzaModel.Pizza p)
    {
      var newPizza = new Pizza();
      newPizza.Name = p.Name.PizzaName;
      newPizza.NameNavigation = new Name() { Name1 = p.Name.PizzaName };
      newPizza.Crust = new Crust() { Name = p.Crust.PizzaCrust, Price = p.Crust.CrustPrice };
      newPizza.Size = new Size() { Name = p.Size.PizzaSize, Price = p.Size.SizePrice };
      newPizza.Price = p.PizzaPrice;
      foreach (var t in p.Toppings) // extract toppings from pizza toppings
      {
        var topping = new Topping() { Name = t.Name, Price = t.Price };
        var pizzaTopping = new PizzaTopping() { Pizza = newPizza, Topping = topping };
        topping.PizzaTopping.Add(pizzaTopping);
        newPizza.PizzaTopping.Add(pizzaTopping);
      }
      return newPizza;
    }
    public List<domain.PizzaModel.Pizza> GetPizzasByUser(string username)
    {
      var domainUserPizzaList = new List<domain.PizzaModel.Pizza>();

      var query = _db.Order.Include(u => u.User).Where(u => u.User.Name == username);
      var extendedQuery = query.Include(o => o.OrderPizza).ThenInclude(p => p.Pizza).ThenInclude(c => c.Crust)
        .Include(o => o.OrderPizza).ThenInclude(p => p.Pizza).ThenInclude(s => s.Size)
        .Include(o => o.OrderPizza).ThenInclude(p => p.Pizza).ThenInclude(pt => pt.PizzaTopping).ThenInclude(t => t.Topping);

      foreach (var q in extendedQuery)
      {
        // System.Console.WriteLine(q.User.Name);
        // System.Console.WriteLine(q.DateTime);
        foreach (var ran in q.OrderPizza)
        {
          var toppings = new List<domain.PizzaModel.Topping>();
          foreach (var pt in ran.Pizza.PizzaTopping)
          {
            var topping = new domain.PizzaModel.Topping() { Name = pt.Topping.Name, Price = (double)pt.Topping.Price };
            toppings.Add(topping);
          }
          // System.Console.WriteLine(ran.Pizza.Name);
          domainUserPizzaList.Add(new domain.PizzaModel.Pizza()
          {
            Name = new domain.PizzaModel.Name() { PizzaName = ran.Pizza.Name },
            Crust = new domain.PizzaModel.Crust() { PizzaCrust = ran.Pizza.Crust.Name, CrustPrice = (double)ran.Pizza.Crust.Price },
            Size = new domain.PizzaModel.Size() { PizzaSize = ran.Pizza.Size.Name, SizePrice = (double)ran.Pizza.Size.Price },
            PizzaPrice = ran.Pizza.Price,
            Toppings = toppings
          });
        }
      }
      return domainUserPizzaList;
    }
  }
}