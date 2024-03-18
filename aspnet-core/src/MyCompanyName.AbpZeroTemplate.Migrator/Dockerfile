#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MyCompanyName.AbpZeroTemplate.Migrator/MyCompanyName.AbpZeroTemplate.Migrator.csproj", "src/MyCompanyName.AbpZeroTemplate.Migrator/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.EntityFrameworkCore/MyCompanyName.AbpZeroTemplate.EntityFrameworkCore.csproj", "src/MyCompanyName.AbpZeroTemplate.EntityFrameworkCore/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.Core/MyCompanyName.AbpZeroTemplate.Core.csproj", "src/MyCompanyName.AbpZeroTemplate.Core/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.Core.Shared/MyCompanyName.AbpZeroTemplate.Core.Shared.csproj", "src/MyCompanyName.AbpZeroTemplate.Core.Shared/"]
RUN dotnet restore "src/MyCompanyName.AbpZeroTemplate.Migrator/MyCompanyName.AbpZeroTemplate.Migrator.csproj"
COPY . .
WORKDIR "/src/src/MyCompanyName.AbpZeroTemplate.Migrator"
RUN dotnet build "MyCompanyName.AbpZeroTemplate.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCompanyName.AbpZeroTemplate.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCompanyName.AbpZeroTemplate.Migrator.dll", "-s"]
