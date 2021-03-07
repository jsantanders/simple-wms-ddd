#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Server/ProjectName.Api/ProjectName.Api.csproj", "Server/ProjectName.Api/"]
COPY ["Server/ProjectName.Infrastructure/ProjectName.Infrastructure.csproj", "Server/ProjectName.Infrastructure/"]
COPY ["Server/ProjectName.Application/ProjectName.Application.csproj", "Server/ProjectName.Application/"]
COPY ["Server/ProjectName.Domain/ProjectName.Domain.csproj", "Server/ProjectName.Domain/"]
RUN dotnet restore "Server/ProjectName.Api/ProjectName.Api.csproj"
COPY . .
WORKDIR "/src/Server/ProjectName.Api"
RUN dotnet build "ProjectName.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectName.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectName.Api.dll"]
