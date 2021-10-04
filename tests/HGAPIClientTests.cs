using System;
using Xunit;

namespace StockAlert.Tests
{
  public class HGAPIClientTests
  {
    [Fact]
    public void Test1()
    {
      HGAPIClient client = new HGAPIClient();
      var stockPrice = client.GetStockPrice("petr4");

      Assert.IsType<Decimal>(stockPrice);
    }
  }
}
