# stock-alert

Console application to monitor stock prices, compare it to a reference value and trigger a email alert recommending selling ou buying.

To run the aplication:
- Create a .env file following the .env.example structure;
- The API used was the HG FInance https://console.hgbrasil.com/documentation/finance
- The email delivery service used was SendGrid https://sendgrid.com/

In the console run the command passing 3 arguments
- The stock to monitor
- The reference selling value
- The reference Buying value

For example:
```bash
dotnet run petr4 23.5 21.5
```
