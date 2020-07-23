using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    public Pizza()
    {
    }

    public Pizza(string name, string size, string crust, List<string> toppings)
    {
      Name = name;
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);
    }

    List<string> _toppings = new List<string>();

    public string Name { get; set; }
    public string Size { get; set; } // TODO remove setter later

    public string Crust { get; set; }
    public List<string> Toppings { get { return _toppings; } } // might need a _backing field to return proper val

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var t in Toppings)
      {
        sb.Append(t + " ");
      }
      return $"Pizza name: {Name} \nsize: {Size} \ntoppings: {sb} \ncrust: {Crust}";
    }

  }
}