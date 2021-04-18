Company X assignment for backend programmer by Andris

# Vacation Hire documentation


 
## Installation

Assigment requires usage of external currency service API KEY that is stored in user secrets. 
Get your API key by registering at https://currencylayer.com/

Either set this through UI for VH.DataService or using command line:
dotnet user-secrets set "CurrencyApiKey" "YOUR_API_KEY" --project "VH.DataService"

https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows#set-a-secret

## Usage

API Service is usable locally as well as it is deployed in Azure. 

https://vh-be.azurewebsites.net/api/

API description/documantation is provided by Swagger and can be found on 
https://vh-be.azurewebsites.net/index.html


## API Endpoints

GET: `/api/order/orders` - list all orders

GET: `/api/order/5 ` - get specific order

GET: `/api/asset`  - list all assets
POST: `/api/order/`

GET: `/api/poc-showcase/currencyservice` - Showcase of external api usage for currency service

## Creating an order sample payload

```
{
  "from": "2021-04-18T20:16:30.637Z",
  "to": "2021-04-18T20:16:30.637Z",
  "customer": {
    "name": "Test User Name",
    "email": "sample.user@foo.bar",
"adress":"Testing lane 1, BZ",
    "age": 67
  },
  "asset": {
    "id": 1

  }
}
```



## Extensibility
Data model of the application is compatable to be extended for other types of rentable Assets. Main difference would be way of calculating price for the items. 

Different properties of the assets would be stored in `properties` column for the Asset. Depenting on the asset type different calculation and return procedure could be implemented. 



## Out of Scope 
As time is limited, here will be a list of assumptions and items that are out of scope for this sample task

Items that are left out of scope and short comment about them:
### Authentication
Authentication for API and client can be done in one of many ways, but more of web-friendly approach would be of 

### Caching of currency service responses for performance and resilience
In real world high request volume scenario live currency exchange rate does not change that often and should be cached as well as to save on request ammount and to create a resiliancy path if external API provider is down.

### Full test coverage

Althou testing is being done in this assignment, full test coverage was not possible due to time limitations.

### API input validation

API Input validation is missing, but is needed. Same reason: time limitations.

### More descriptive API description
API Description is provided using Swagger. But more meaningflu descriptions are possible when utilizing full extent of the possibilities and attributes for swagger.

