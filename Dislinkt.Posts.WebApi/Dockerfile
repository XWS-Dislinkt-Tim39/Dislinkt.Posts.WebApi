#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["./Dislinkt.Posts.WebApi/Dislinkt.Posts.WebApi.csproj", "Dislinkt.Posts.WebApi/"]
COPY ["./Dislinkt.Posts/Dislinkt.Posts.csproj", "Dislinkt.Posts/"]
COPY ["./Dislinkt.Posts.Domain/Dislinkt.Posts.Domain.csproj", "Dislinkt.Posts.Domain/"]
COPY ["./Dislinkt.Posts.Persistance.MongoDB/Dislinkt.Posts.Persistance.MongoDB.csproj", "Dislinkt.Posts.Persistance.MongoDB/"]
COPY ["./Dislinkt.Posts.Core/Dislinkt.Posts.Core.csproj", "Dislinkt.Posts.Core/"]
COPY ["./Dislinkt.Posts.Application/Dislinkt.Posts.Application.csproj", "Dislinkt.Posts.Application/"]

COPY . .
WORKDIR "./Dislinkt.Posts.WebApi/Dislinkt.Posts.WebApi"
RUN dotnet build "Dislinkt.Posts.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dislinkt.Posts.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dislinkt.Posts.WebApi.dll"]