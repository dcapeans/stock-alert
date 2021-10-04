using System;
using System.Threading.Tasks;

namespace StockAlert
{
  class IntervalManager
  {
    public static async Task SetInterval(Action action, int minutes = 5)
    {
      TimeSpan interval = TimeSpan.FromMinutes(minutes);
      await Task.Delay(interval).ConfigureAwait(false);

      action();

      await SetInterval(action, minutes);
    }

  }
}