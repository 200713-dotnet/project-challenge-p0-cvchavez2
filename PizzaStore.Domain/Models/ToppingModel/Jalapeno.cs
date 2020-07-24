using PizzaStore.Domain.Models.PizzaModel;

namespace PizzaStore.Domain.Models.ToppingModel
{
  public class Jalapeno : Topping
  {
    const double JALAPENO_PRICE = 0.5;
    const string NAME = "Jalapeno";
    public Jalapeno()
    {
    }

    public override double Price
    {
      get
      { return JALAPENO_PRICE; }
    }

    public override string Name { get { return NAME; } }
  }
}