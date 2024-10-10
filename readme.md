# ECOMMERCE SHOPPING CART MICROSERVICE
ShoppingCart service for the [ecommerce microservices][1].

The *Shopping Cart* service handle a user's cart.

## SETUP DEVELOPMENT ENVIRONMENT
### Dotnet
To simply run it on dotnet CLI: `dotnet run`.

## SETUP PRODUCTION ENVIRONMENT
Visit the [master repo][1] to view instructions.

## API USAGE
### Exposed endpoint

A full list of all exposed endpoint can be found in the swagger URL `/swagger`.

Endpoint | HTTP Method | Description | Method name
--- | --- | --- | ---
`/` | get | Test if the Cart service and the others services it depends on are working | Index
`/status` | get | Test if the service is working but return a plain string | GetStatus
`/<userId>` | get | Get a user's cart | GetUserCart
`<userId>/item` | post | Add on item to a user's cart | AddItem
`<userId>/items` | post | Add multiple items to a user cart | AddItems

### Body data
wip

### About the project
- Database: mariadb
- Database name: *shopping_cart*

## RESOURCES
- [Containerize a .NET app](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=linux&pivots=dotnet-8-0)

[1]: https://gitlab.com/HarimbolaSantatra/ecommerce-microservices
