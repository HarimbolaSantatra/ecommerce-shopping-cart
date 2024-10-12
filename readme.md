# MUSIC STREAM BACKEND
Backend for the [music stream microservice][1].

## SETUP DEVELOPMENT ENVIRONMENT
- To simply run it on dotnet CLI: `dotnet run`.
- Using Docker:

    docker build -t cart-svc .
    docker run -it -d --rm --name cart-svc cart-svc

## SETUP PRODUCTION ENVIRONMENT
Visit the [master repo][1] to view instructions.

## API USAGE

A full list of all exposed endpoint can be found in the swagger URL `/swagger`.

## About the project
- Database: mariadb
- Database name: *music_stream*

[1]: https://github.com/HarimbolaSantatra/music-stream-master
