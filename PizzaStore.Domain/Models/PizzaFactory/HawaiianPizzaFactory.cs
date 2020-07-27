using System.Collections.Generic;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;

namespace PizzaStore.Domain.Models
{
  public class HawaiianPizzaFactory : Pizza
  {
    public HawaiianPizzaFactory() : base(new Name("Hawaiian"),new Size("M"),new Crust("Regular"),new List<Topping>{new Pineapple(), new Ham()})
    {
    }
    public new Pizza MakePizza()
    {
      return new Pizza(new Name("Hawaiian"),new Size("M"),new Crust("Regular"),new List<Topping>{new Pineapple(), new Ham()});
    }
  }
}