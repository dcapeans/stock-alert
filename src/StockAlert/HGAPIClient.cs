using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using dotenv.net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StockAlert
{
  class HGAPIClient : HttpClient
  {
    public String Url { get; set; }
    private String Key { get; set; }
    private String StockSymbol { get; set; }
    public HGAPIClient(String url = "https://api.hgbrasil.com/finance")
    {
      // todo: change to env variable
      DotEnv.Load();
      var envKey = DotEnv.Read();
      //Key = EnvReader.GetStringValue("HG_API_KEY");
      Key = envKey["HG_API_KEY"];
      Url = url;
    }

    public void GetStockPrice(string StockSymbol)
    {
      string normalizedStockSymbol = StockSymbol.ToUpper();
      string stockUrl = this.Url + $"/stock_price?key={this.Key}&symbol={normalizedStockSymbol}";
      var response = this.GetAsync(stockUrl).Result;

      if (response.IsSuccessStatusCode)
      {
        var result = response.Content.ReadAsStringAsync().Result;
        ApiResult apiResult = JsonConvert.DeserializeObject<ApiResult>(result);

        Console.WriteLine(apiResult.results[normalizedStockSymbol].price);
      }
    }
  }

  public class ApiResult
  {
    public dynamic results { get; set; }
    public string by { get; set; }
    public bool valid_key { get; set; }
    public bool from_cache { get; set; }
    public double execution_time { get; set; }
  }
}