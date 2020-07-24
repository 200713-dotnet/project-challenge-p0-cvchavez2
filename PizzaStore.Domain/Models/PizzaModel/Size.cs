namespace PizzaStore.Domain.Models.PizzaModel
{
  public class Size
  {
    const double SMALL = 5.0D;
    const double MEDIUM = 7.0D;
    const double LARGE = 9.0D;
    const double XLARGE = 11.0D;

    string _size = "";

    public Size()
    {
      PizzaSize = "M";
      AssignPrice();
    }
    public Size(string size)
    {
      PizzaSize = size;
      AssignPrice();
    }

    void AssignPrice()
    {
      switch (PizzaSize)
      {
        case "S":
          SizePrice = SMALL;
          break;
        case "M":
          SizePrice = MEDIUM;
          break;
        case "L":
          SizePrice = LARGE;
          break;
        case "XL":
          SizePrice = XLARGE;
          break;
      }
    }

    public string PizzaSize
    {
      get
      {
        return _size;
      }
      set
      {
        _size = value;
        AssignPrice();
      }
    }
    public double SizePrice { get; set; }

  }
}