using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models.ToppingModel
{
  public class Cheese : Topping
  {
    const double CHEESE_PRICE = 0.7;
    const string NAME = "Cheese";

    public Cheese()
    {
    }

    public override double Price
    {
      get
      { return CHEESE_PRICE; }
    }
    public override string Name { get { return NAME; } }

  }
}