# Étape 1 : Utiliser une image de base pour le build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copier le fichier .csproj et restaurer les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copier le reste des fichiers et construire l'application
COPY . ./
RUN dotnet publish -c Release -o out

# Étape 2 : Utiliser une image de base pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copier les fichiers publiés de l'étape précédente
COPY --from=build-env /app/out .

# Exposer le port utilisé par l'application
EXPOSE 80

# Démarrer l'application
ENTRYPOINT ["dotnet", "api-echallenge.dll"]
