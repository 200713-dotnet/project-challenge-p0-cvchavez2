namespace PizzaStore.Domain.Models.PizzaModel
{
  public class Crust
  {
    const double REGULAR_CRUST = 0.0D;
    const double CHEESE_STUFFED_CRUST = 1.0D;
    const double FLATBREAD_CRUST = 0.5D;
    public Crust()
    {
      PizzaCrust = "regular";
      AssignPrice(); // Not sure about this
    }
    public Crust(string crust)
    {
      PizzaCrust = crust;
      AssignPrice(); // Not sure about this
    }
    void AssignPrice()
    {
      switch(PizzaCrust)
      {
        case "regular":
          CrustPrice = REGULAR_CRUST;
          break;
        case "stuffed":
          CrustPrice = CHEESE_STUFFED_CRUST;
          break;
        case "flatbread":
          CrustPrice = FLATBREAD_CRUST;
          break;
      }
    }

    public string PizzaCrust { get; set; }

    public double CrustPrice { get; set; }
    
  }
}