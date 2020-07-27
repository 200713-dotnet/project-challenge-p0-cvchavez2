using System.Collections.Generic;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;

namespace PizzaStore.Domain.Models
{
  public class PepperoniPizzaFactory : Pizza
  {
    public PepperoniPizzaFactory() : base(new Name("Pepperoni"),new Size("M"),new Crust("Regular"),new List<Topping>{new Pepperoni(), new Cheese()})
    {
    }
    public new Pizza MakePizza()
    {
      return new Pizza(new Name("Pepperoni"),new Size("M"),new Crust("Regular"),new List<Topping>{new Pepperoni(), new Cheese()});
    }
  }
}