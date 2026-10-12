# Use SDK to build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# copy and restore as distinct layer for better caching
COPY *.csproj .
RUN dotnet restore

# copy remaining source and build app
COPY . .
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["dotnet", "EBookPresenter.dll"]
