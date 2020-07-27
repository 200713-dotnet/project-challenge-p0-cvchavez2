using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models.ToppingModel
{
  public class Mushrooms : Topping
  {
    const double MUSHROOMS_PRICE = 0.9;
    const string NAME = "Mushrooms";
    public Mushrooms()
    {
    }

    public override double Price
    {
      get
      { return MUSHROOMS_PRICE; }
    }

    public override string Name { get { return NAME; } }
  }
}