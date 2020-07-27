using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models.ToppingModel
{
  public class Olives : Topping
  {
    const double OLIVES_PRICE = 0.35;
    const string NAME = "Olives";
    public Olives()
    {
    }

    public override double Price
    {
      get
      { return OLIVES_PRICE; }
    }

    public override string Name { get { return NAME; } }
  }
}