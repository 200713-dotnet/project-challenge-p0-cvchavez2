using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.Domain.Models.PizzaModel
{
  public class Pizza
  {
    public Pizza()
    {
    }

    public Pizza(Name name, Size size, Crust crust, List<Topping> toppings)
    {
      Name = name;
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);
      ComputePizzaPrice(); // Not sure if this is correct here
    }

    List<Topping> _toppings = new List<Topping>();

    public Name Name { get; set; }
    public Size Size { get; set; } // TODO remove setter later

    public Crust Crust { get; set; }
    public List<Topping> Toppings { get { return _toppings; } } // might need a _backing field to return proper val

    public double PizzaPrice { get; set; }

    public void ComputePizzaPrice(){
      PizzaPrice = Size.SizePrice + Crust.CrustPrice + _toppings.Sum(Topping => Topping.Price); // TODO toppings price
    }
    public void EditPizzaName(string name)
    {
      // Size = size;
    }  
    public void EditPizzaSize(string size)
    {
      // Size = size;
    }
    public void EditPizzaCrust(string crust)
    {
      // Crust = crust;
    }
    public void EditPizzaToppings(List<Topping> toppings)
    {
      Toppings.AddRange(toppings);
    }
    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var t in Toppings)
      {
        sb.Append(t.Name + " ");
      }
      return $"Pizza name: {Name.PizzaName} \nsize: {Size.PizzaSize} \ntoppings: {sb} \ncrust: {Crust.PizzaCrust} \nPRICE: ${PizzaPrice}";
    }

  }
}