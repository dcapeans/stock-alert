using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockAlert
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Press ENTER to end program");
      // Task task = IntervalManager.SetInterval(() => Console.WriteLine("Hello from SetInterval"), 2);
      HGAPIClient client = new HGAPIClient();
      client.GetStockPrice();
      Console.ReadLine();
    }
  }
}
