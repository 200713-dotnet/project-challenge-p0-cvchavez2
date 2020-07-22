using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    public Pizza()
    {
    }

    public Pizza(string size, string crust, List<string> toppings)
    {
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);

    }
    public string Size { get; set; } // TODO remove setter later

    public string Crust { get; set; }

    public List<string> Toppings { get; set; } // might need a _backing field to return proper val

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var t in Toppings)
      {
        sb.Append(t + " ");
      }
      return $"size: {Size} \ntoppings: {sb} \ncrust: {Crust}";
    }
    
  }
}