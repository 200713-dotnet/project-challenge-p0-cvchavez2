namespace PizzaStore.Client
{
  public class StoreStarter
  {
    public static void StoreMenu()
    {
      System.Console.WriteLine("Select 1 for West (In-Progress)");
      System.Console.WriteLine("Select 2 for East (In-Progress)");
      System.Console.WriteLine("Select 3 to view all orders");
      System.Console.WriteLine("Select 99 to Exit");
      System.Console.WriteLine();
    }
    internal static void ManageStoreMenu()
    {
      System.Console.WriteLine("Select 1 to view Store Order History");
      System.Console.WriteLine("Select 2 to view Store Sales");
      System.Console.WriteLine("Select 99 to Exit");
    }
    internal static void OrderHistoryMenu()
    {
      System.Console.WriteLine("Select 1 to view all Store Orders");
      System.Console.WriteLine("Select 2 to view Orders by User");
      System.Console.WriteLine("Select 99 to Exit");
    }
  }
}