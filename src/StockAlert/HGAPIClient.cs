using System;
using System.Net.Http;
using dotenv.net;
using Newtonsoft.Json;

namespace StockAlert
{
  class HGAPIClient : HttpClient
  {
    public String Url { get; set; }
    private String Key { get; set; }
    private String StockSymbol { get; set; }
    public HGAPIClient(String url = "https://api.hgbrasil.com/finance")
    {
      var env = DotEnv.Read();
      Key = env["HG_API_KEY"];
      Url = url;
    }

    public decimal GetStockPrice(string StockSymbol)
    {
      string normalizedStockSymbol = StockSymbol.ToUpper();
      string stockUrl = this.Url + $"/stock_price?key={this.Key}&symbol={normalizedStockSymbol}";
      var response = this.GetAsync(stockUrl).Result;

      if (response.IsSuccessStatusCode)
      {
        var result = response.Content.ReadAsStringAsync().Result;
        ApiResult apiResult = JsonConvert.DeserializeObject<ApiResult>(result);

        return apiResult.results[normalizedStockSymbol].price;
      }
      throw new Exception();
    }
  }
}