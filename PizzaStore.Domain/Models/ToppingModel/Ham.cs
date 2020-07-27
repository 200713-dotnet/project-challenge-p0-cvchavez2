using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models.ToppingModel
{
  public class Ham : Topping
  {
    const double HAM_PRICE = 0.6;
    const string NAME = "Ham";
    public Ham()
    {
    }

    public override double Price
    {
      get
      { return HAM_PRICE; }
    }

    public override string Name { get { return NAME; } }
  }
}