using System.Threading.Tasks;
using dotenv.net;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace StockAlert
{
  internal class EmailClient
  {
    public static async Task Execute(string emailBody)
    {
      var env = DotEnv.Read();
      var apiKey = env["SENDGRID_API_KEY"];
      var client = new SendGridClient(apiKey);
      var from = new EmailAddress(env["FROM_EMAIL"]);
      var subject = "Stock Price Alert";
      var to = new EmailAddress(env["TO_EMAIL"]);
      var plainTextContent = emailBody;
      var htmlContent = $"<strong>{emailBody}</strong>";
      var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
      var response = await client.SendEmailAsync(msg);
    }
  }
}