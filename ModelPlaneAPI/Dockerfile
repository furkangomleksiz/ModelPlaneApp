# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY ModelPlaneAPI/*.csproj ./ModelPlaneAPI/
RUN dotnet restore

# Copy the remaining files and build
COPY . .
WORKDIR /app/ModelPlaneAPI
RUN dotnet publish -c Release -o out

# Use the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/ModelPlaneAPI/out .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "ModelPlaneAPI.dll"]
