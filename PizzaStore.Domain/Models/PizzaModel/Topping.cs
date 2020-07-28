using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models.PizzaModel
{
  public class Topping
  {
    public Topping()
    {
    }
    public Topping(string name)
    {
      Name = name;
    }
    public Topping(string name, double price)
    {
      Name = name;
      Price = price;
    }
    public Topping(List<Topping> toppings)
    {

    }

    public virtual string Name { get; set; }
    public virtual double Price { get; set; }

    public override string ToString()
    {
      return $"{Name} \nprice: {Price}";
    }
    // public List<Topping> Toppings { get; set; }
  }
}