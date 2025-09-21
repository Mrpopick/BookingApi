#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RoomApi/RoomApi.csproj", "RoomApi/"]
COPY ["RoomApi.Applications/RoomApi.Applications.csproj", "RoomApi.Applications/"]
COPY ["RoomApi.Domain/RoomApi.Domain.csproj", "RoomApi.Domain/"]
COPY ["RoomApi.Infrastructure/RoomApi.Infrastructure.csproj", "RoomApi.Infrastructure/"]
RUN dotnet restore "./RoomApi/RoomApi.csproj"
COPY . .
WORKDIR "/src/RoomApi"
RUN dotnet build "./RoomApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoomApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomApi.dll"]