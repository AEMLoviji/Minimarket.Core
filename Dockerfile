FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Minimarket.API/*.csproj ./Minimarket.API/
RUN dotnet restore

# Copy everything else and build
COPY Minimarket.API/. ./Minimarket.API/
WORKDIR /app/Minimarket.API
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/Minimarket.API/out ./
CMD dotnet src/Minimarket.API.dll