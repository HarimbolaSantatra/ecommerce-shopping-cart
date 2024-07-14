# ECOMMERCE SHOPPING CART MICROSERVICE
ShoppingCart services for the [ecommerce microservices][1].
Master repo is [here](https://github.com/HarimbolaSantatra/gammerlgaard-shopping-cart).

## SETUP DEVELOPMENT ENVIRONMENT
### Dotnet
To simply run it on dotnet CLI: `dotnet run`.

## SETUP PRODUCTION ENVIRONMENT
Visit the [master repo][1] to view instructions.

## API USAGE
### Exposed endpoint

Here's a list of all exposed endpoint of the API. The base URL is `shoppingcart`.
Endpoint | HTTP Method | Description | Method name
--- | --- | --- | ---
`/` | get | Test if the Cart service and the others services it depends on are working | Index
`/status` | get | Test if the service is working but return a plain string | GetStatus
`/<userId>` | get | Get a user's cart | GetUserCart
`<userId>/item` | post | Add on item to a user's cart | AddItem
`<userId>/items` | post | Add multiple items to a user cart | AddItems

### Body data

### About the project
- Database: mariadb
- Database name: *account_microservice*



## RESOURCES
- [Containerize a .NET app](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=linux&pivots=dotnet-8-0)

[1]: https://gitlab.com/HarimbolaSantatra/ecommerce-microservices
