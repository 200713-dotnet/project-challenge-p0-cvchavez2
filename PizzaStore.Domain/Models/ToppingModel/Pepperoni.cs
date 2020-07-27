using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models.ToppingModel
{
  public class Pepperoni : Topping
  {
    const double PEPPERONI_PRICE = 0.4;
    const string NAME = "Pepperoni";
    public Pepperoni()
    {
    }

    public override double Price
    {
      get
      { return PEPPERONI_PRICE; }
    }

    public override string Name { get { return NAME; } }
  }
}