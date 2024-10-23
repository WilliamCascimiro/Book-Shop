# #See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# USER app
# WORKDIR /app
# EXPOSE 8080
# EXPOSE 8081

# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG BUILD_CONFIGURATION=Release
# WORKDIR /src
# COPY ["Book.API.csproj", "."]
# RUN dotnet restore "./././Book.API.csproj"
# COPY . .
# WORKDIR "/src/."
# RUN dotnet build "./Book.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# FROM build AS publish
# ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish "./Book.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Book.API.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/book-api/Book.API/Book.API.csproj", "book-api/Book.API/"]
COPY ["src/book-api/Book.Application/Book.Application.csproj", "book-api/Book.Application/"]
COPY ["src/book-api/Book.Infra.IoC/Book.Infra.IoC.csproj", "book-api/Book.Infra.IoC/"]
COPY ["src/book-api/Book.Infra.Data/Book.Infra.Data.csproj", "book-api/Book.Infra.Data/"]
COPY ["src/book-api/Book.Domain/Book.Domain.csproj", "book-api/Book.Domain/"]
RUN dotnet restore "book-api/Book.API/Book.API.csproj"


COPY . .
WORKDIR "/src/book-api/Book.API"
RUN dotnet build "Book.API.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Book.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Book.API.dll"]