namespace PizzaStore.Domain.Models.PizzaModel
{
  public class Name
  {
    public Name()
    {
      PizzaName = "Cheese";
    }
    public Name(string name)
    {
      PizzaName = name;
    }

    public string PizzaName { get; set; }
    
  }
}