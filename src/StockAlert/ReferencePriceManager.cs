using System.Threading.Tasks;

namespace StockAlert
{
  class ReferencePriceManager
  {
    public static void CompareReferencesWithStockPrice(decimal stockPrice, decimal refSellPrice, decimal refBuyPrice)
    {
      if (stockPrice > refSellPrice)
      {
        // send email to sell stock
        string emailText = "The stock price exceeded your reference value for sale. \n It's recommended to sell now.";
        EmailClient.Execute(emailText).Wait();
      }
      else if (stockPrice < refBuyPrice)
      {
        // send email to buy stock
        string emailText = "The stock price is below your reference value for buying. \n It's recommended to buy now.";
        EmailClient.Execute(emailText).Wait();
      }
    }
  }
}