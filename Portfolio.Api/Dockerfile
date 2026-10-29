# Stage 1: Build and publish the application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Portfolio.Api.csproj", "./"]
RUN dotnet restore "Portfolio.Api.csproj"

COPY . .
RUN dotnet publish "Portfolio.Api.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Run the published application
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Portfolio.Api.dll"]
