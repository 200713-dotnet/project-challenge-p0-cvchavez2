using System.Collections.Generic;

namespace PizzaStore.Domain.Models.PizzaModel
{
  public class Topping
  {

    const string NAME = "Topping";

    public Topping()
    {

    }
    public Topping(List<Topping> toppings)
    {
      
    }

    public virtual string Name { get { return NAME; } }
    public virtual double Price { get; }


    public List<Topping> Toppings { get; set; }
  }
}