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
      Task task = SetInterval(() => Console.WriteLine("Hello from SetInterval"), TimeSpan.FromSeconds(2));

      Console.ReadLine();
    }

    private static async Task SetInterval(Action action, TimeSpan interval)
    {
      await Task.Delay(interval).ConfigureAwait(false);

      action();

      await SetInterval(action, interval);
    }
  }
}
