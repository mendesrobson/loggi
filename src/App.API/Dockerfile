FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY source/App.API/App.API.csproj source/App.API/
RUN dotnet restore source/App.API/App.API.csproj
COPY . .
WORKDIR /src/source/App.API
RUN dotnet build App.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish App.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "App.API.dll"]
