using System;
using System.Net.Http;
using dotenv.net;

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

    public async void GetStockPrice()
    {
      string response = await this.GetStringAsync(this.Url);

      //Console.WriteLine(response);
      Console.WriteLine(this.Url);
    }
  }
}