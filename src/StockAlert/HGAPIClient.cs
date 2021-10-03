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
    public HGAPIClient(String url = "https://api.hgbrasil.com/finance")
    {
      // todo: change to env variable
      DotEnv.Load();
      var envKey = DotEnv.Read();
      //Key = EnvReader.GetStringValue("HG_API_KEY");
      Key = envKey["HG_API_KEY"];
      Url = url + $"/stock_price?key={this.Key}&symbol=bidi4";
    }

    public void GetStockPrice()
    {
      var response = this.GetStringAsync(this.Url).Result;

      ApiResult responseJson = JsonConvert.DeserializeObject<ApiResult>(response);

      Console.WriteLine(responseJson.results.price);
    }
  }

  public class ApiResult
  {
    public ApiResult()
    {
      this.results = new StockInfo();
    }
    [JsonProperty(PropertyName = "results")]
    public StockInfo results { get; set; }
  }

  public class StockInfo
  {
    [JsonProperty(PropertyName = "price")]
    public double price { get; set; }
  }
}