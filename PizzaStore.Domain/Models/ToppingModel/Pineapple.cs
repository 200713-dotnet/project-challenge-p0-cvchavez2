using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models.ToppingModel
{
  public class Pineapple : Topping
  {
    const double PINEAPPLE_PRICE = 0.80D;
    const string NAME = "Pineapple";
    public Pineapple()
    {
    }

    public override double Price
    {
      get
      { return PINEAPPLE_PRICE; }
    }

    public override string Name { get { return NAME; } }
  }
}