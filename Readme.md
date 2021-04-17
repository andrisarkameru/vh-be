Company X assignment for backend programmer by Andris Pakulis

# Vacation Hire documentation


 
## Installation

Assigment requires usage of external currency service API KEY that is stored in user secrets. 
Get your API key by registering at https://currencylayer.com/

Either set this through UI for VH.DataService or using command line:
dotnet user-secrets set "CurrencyApiKey" "YOUR_API_KEY" --project "VH.DataService"

https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows#set-a-secret

## Usage

## Testing




## Out of Scope 
As time is limited, here will be a list of assumptions and items that are out of scope for this sample task

Items that are left out of scope and short comment about them:
### Authentication
Authentication for API and client can be done in one of many ways, but more of web-friendly approach would be of 

### Caching of currency service responses for performance and resilience
In real world high request volume scenario live currency exchange rate does not change that often and should be cached as well as to save on request ammount and to create a resiliancy path if external API provider is down.


### Full test coverage
