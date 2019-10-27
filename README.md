[![CircleCI](https://circleci.com/gh/AEMLoviji/Minimarket.Core.svg?style=svg)](https://circleci.com/gh/AEMLoviji/Minimarket.Core)

# Minimarket API
RESTful API built with ASP.NET Core v2.2. The main purpose was to fix and share how to create RESTful service using maintainable architecture where modules decoupled and allows features to be added easily.

## Frameworks and Libraries
- [ASP.NET Core 2.2](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2) - for building WEB API;
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - for data access;
- [Entity Framework In-Memory Provider](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory) - for testing purposes;
- [AutoMapper](https://automapper.org/) - for object2object mapping;

## CI/CD
[Circle-CI](https://circleci.com/) is used as CI/CD pipeline where configuration is stored in [Circle-CI config file](.circle-ci/config.yml) and automatically executes JOBS defined in config.yml file when new commit to master branch is pushed to the server. Build job consist of listed below commands.
 - Checkouts the latest source from master branch.
 - Builds docker image using [Dockerfile](Dockerfile).
 - Deploys docker image to Heroku.
 
 ## Heroku
 In order to protect secrets used in deployment process HEROKU specific variables are stored as Circle-CI environment variables. https://minimarket-api.herokuapp.com 
 
