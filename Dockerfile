FROM registry.access.redhat.com/dotnet/dotnet-22-rhel7:2.2-13

WORKDIR /app
COPY publish/. .

EXPOSE 8080

CMD [ "dotnet", "App.API.dll" ]