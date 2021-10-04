using System;
using System.Threading;
using System.Threading.Tasks;
using dotenv.net;

namespace StockAlert
{
  class Program
  {
    static void Main(string[] args)
    {
      DotEnv.Load();
      string stockSymbol = (args[0]);
      decimal sellValue = Decimal.Parse(args[1]);
      decimal buyValue = Decimal.Parse(args[2]);
      Console.WriteLine("Press ENTER to end program");
      HGAPIClient client = new HGAPIClient();
      // Task task = IntervalManager.SetInterval(() => Console.WriteLine("Hello from SetInterval"), 2);
      var stockPrice = client.GetStockPrice(stockSymbol);
      ReferencePriceManager.CompareReferencesWithStockPrice(stockPrice, sellValue, buyValue);
      Console.ReadLine();
    }
  }
}
