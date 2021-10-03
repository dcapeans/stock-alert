using System;
using System.Threading.Tasks;

namespace StockAlert
{
  class IntervalManager
  {
    public static async Task SetInterval(Action action, int seconds = 2)
    {
      TimeSpan interval = TimeSpan.FromSeconds(seconds);
      await Task.Delay(interval).ConfigureAwait(false);

      action();

      await SetInterval(action, seconds);
    }

  }
}