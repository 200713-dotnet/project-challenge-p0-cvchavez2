using System.Collections.Generic;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;

namespace PizzaStore.Domain.Models
{
  public class CheesePizzaFactory : Pizza
  {
    public CheesePizzaFactory() : base(new Name("Cheese"),new Size("M"),new Crust("Regular"),new List<Topping>{new Cheese(), new Cheese()})
    {
    }
    public new Pizza MakePizza()
    {
      return new Pizza(new Name("Cheese"),new Size("M"),new Crust("Regular"),new List<Topping>{new Cheese(), new Cheese()});
    }
  }
}