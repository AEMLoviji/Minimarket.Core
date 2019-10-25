FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Minimarket.API/*.csproj ./Minimarket.API/
RUN dotnet restore

# copy everything else and build app
COPY Minimarket.API/. ./Minimarket.API/
WORKDIR /app/Minimarket.API
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/Minimarket.API/out ./
ENTRYPOINT ["dotnet", "Minimarket.API.dll"]