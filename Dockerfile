#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AccountManager.Api/AccountManager.Api.csproj", "AccountManager.Api/"]
COPY ["AccountManager.Application/AccountManager.Application.csproj", "AccountManager.Application/"]
COPY ["AccountManager.Domain/AccountManager.Domain.csproj", "AccountManager.Domain/"]
COPY ["AccountManager.Infrastructure/AccountManager.Infrastructure.csproj", "AccountManager.Infrastructure/"]
RUN dotnet restore "./AccountManager.Api/./AccountManager.Api.csproj"
COPY . .
WORKDIR "/src/AccountManager.Api"
RUN dotnet build "./AccountManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AccountManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountManager.Api.dll"]