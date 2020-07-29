using System.Collections.Generic;
using System.Linq;
// using PizzaStore.Domain.Models.PizzaModel;
// using topModel = PizzaStore.Domain.Models.ToppingModel;
using domain = PizzaStore.Domain.Models.PizzaModel;
using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Storing.Repositories
{
  public class PizzaRepository
  {
    private PizzaStoreDBContext _db = new PizzaStoreDBContext();
    public void Create(domain.Pizza pizza)
    {
      var newPizza = new Pizza();
      newPizza.Name = pizza.Name.PizzaName;
      newPizza.NameNavigation = new Name() { Name1 = pizza.Name.PizzaName };
      newPizza.Crust = new Crust() { Name = pizza.Crust.PizzaCrust, Price = pizza.Crust.CrustPrice };
      newPizza.Size = new Size() { Name = pizza.Size.PizzaSize, Price = pizza.Size.SizePrice };
      newPizza.Price = pizza.PizzaPrice;

      foreach (var t in pizza.Toppings)
      {
        var topping = new Topping() { Name = t.Name, Price = t.Price };
        var pizzaTopping = new PizzaTopping() { Pizza = newPizza, Topping = topping };
        topping.PizzaTopping.Add(pizzaTopping);
        newPizza.PizzaTopping.Add(pizzaTopping);
      }
      _db.Pizza.Add(newPizza);
      System.Console.WriteLine("Added Successfully!");
      _db.SaveChanges();

    }
    public List<domain.Pizza> ReadAll()
    {
      // eager loading
      // lazy loading
      var domainPizzaList = new List<domain.Pizza>();

      var pizzasWithEverything = _db.Pizza.Include(c => c.Crust).Include(s => s.Size).Include(pt => pt.PizzaTopping).ThenInclude(t => t.Topping);

      foreach (var item in pizzasWithEverything.ToList() )
      {
        var toppings = new List<domain.Topping>();
        foreach (var pt in item.PizzaTopping)
        {
          var topping = new domain.Topping() { Name = pt.Topping.Name, Price = (double)pt.Topping.Price };
          toppings.Add(topping);
        }
        domainPizzaList.Add(new domain.Pizza()
        {
          Name = new domain.Name() { PizzaName = item.Name },
          Crust = new domain.Crust() { PizzaCrust = item.Crust.Name, CrustPrice = (double)item.Crust.Price },
          Size = new domain.Size() { PizzaSize = item.Size.Name, SizePrice = (double)item.Size.Price },
          PizzaPrice = item.Price,
          Toppings = toppings
        });
      };
      return domainPizzaList;
    }
    public void Delete()
    {

    }
    public void Update()
    {

    }
  }
}