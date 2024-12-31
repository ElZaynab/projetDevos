FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .

# Installer .NET SDK
RUN apt-get update && apt-get install -y dotnet-sdk-8.0

# Build et publication
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Stage finale
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "api-echallenge.dll"]
