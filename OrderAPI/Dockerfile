#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

#ENV OrderDb="Server=tcp:eshop-ryan.database.windows.net,1433;Initial Catalog=OrderDb;Persist Security Info=False;User ID=ryan;Password=Zet19951008!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderAPI/OrderAPI.csproj", "OrderAPI/"]
COPY ["OrderAPI.Infrastructure/OrderAPI.Infrastructure.csproj", "OrderAPI.Infrastructure/"]
COPY ["OrderAPI.ApplicationCore/OrderAPI.ApplicationCore.csproj", "OrderAPI.ApplicationCore/"]
RUN dotnet restore "./OrderAPI/OrderAPI.csproj"
COPY . .
WORKDIR "/src/OrderAPI"
RUN dotnet build "./OrderAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrderAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderAPI.dll"]