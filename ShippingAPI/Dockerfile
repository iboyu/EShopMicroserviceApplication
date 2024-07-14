#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

ENV ShippingDb="Server=tcp:eshop-ryan.database.windows.net,1433;Initial Catalog=ShippingDb;Persist Security Info=False;User ID=ryan;Password=Zet19951008!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShippingAPI/ShippingAPI.csproj", "ShippingAPI/"]
COPY ["ShippingAPI.Infrastructure/ShippingAPI.Infrastructure.csproj", "ShippingAPI.Infrastructure/"]
COPY ["ShippingAPI.ApplicationCore/ShippingAPI.ApplicationCore.csproj", "ShippingAPI.ApplicationCore/"]
RUN dotnet restore "./ShippingAPI/ShippingAPI.csproj"
COPY . .
WORKDIR "/src/ShippingAPI"
RUN dotnet build "./ShippingAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShippingAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShippingAPI.dll"]