#Parent Image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

#The working dir of the app
WORKDIR /app

# Copy from host to container
COPY . .

ENTRYPOINT ["dotnet", "EBookPresenter.dll"]