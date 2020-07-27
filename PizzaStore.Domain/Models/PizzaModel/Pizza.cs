using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Models.ToppingModel;

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
      Name.PizzaName = name;
    }  
    public void EditPizzaSize(string size)
    {
      Size.PizzaSize = size;
      ComputePizzaPrice();
    }
    public void EditPizzaCrust(string crust)
    {
      Crust.PizzaCrust = crust;
      ComputePizzaPrice();
    }
    public void AddPizzaTopping(Topping topping)
    {
      _toppings.Add(topping);
      ComputePizzaPrice(); // TODO delete computation from here
    }
    public void RemoveTopping(Topping topping)
    {
      _toppings.Remove(topping);
      ComputePizzaPrice(); // TODO delete computation from here
    }
    public void RemoveTopping(int index)
    {
      _toppings.Remove(_toppings.ElementAt(index-1));
      ComputePizzaPrice(); // TODO delete computation from here
    }
    public int ToppingsCount()
    {
      return _toppings.Count; 
    }
    public bool IsToppingsAtRange()
    {
      return ToppingsCount() < 5;
    }
    
    public virtual Pizza MakePizza()
    {
      return new Pizza(new Name("Cheese"),new Size("M"),new Crust("Regular"),new List<Topping>{new Cheese(), new Cheese()});
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