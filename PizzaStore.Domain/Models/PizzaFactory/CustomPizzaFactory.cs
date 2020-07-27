using System.Collections.Generic;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;

namespace PizzaStore.Domain.Models
{
  public class CustomPizzaFactory : Pizza
  {
    public CustomPizzaFactory() : base(new Name("Custom"),new Size("M"),new Crust("Regular"),new List<Topping>{})
    {
    }
    public new Pizza MakePizza()
    {
      return new Pizza(new Name("Custom"),new Size("M"),new Crust("Regular"),new List<Topping>{});
    }
  }
}