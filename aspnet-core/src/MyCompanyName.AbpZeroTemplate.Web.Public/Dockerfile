#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MyCompanyName.AbpZeroTemplate.Web.Public/MyCompanyName.AbpZeroTemplate.Web.Public.csproj", "src/MyCompanyName.AbpZeroTemplate.Web.Public/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.Web.Core/MyCompanyName.AbpZeroTemplate.Web.Core.csproj", "src/MyCompanyName.AbpZeroTemplate.Web.Core/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.Application/MyCompanyName.AbpZeroTemplate.Application.csproj", "src/MyCompanyName.AbpZeroTemplate.Application/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.Application.Shared/MyCompanyName.AbpZeroTemplate.Application.Shared.csproj", "src/MyCompanyName.AbpZeroTemplate.Application.Shared/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.Core.Shared/MyCompanyName.AbpZeroTemplate.Core.Shared.csproj", "src/MyCompanyName.AbpZeroTemplate.Core.Shared/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.Core/MyCompanyName.AbpZeroTemplate.Core.csproj", "src/MyCompanyName.AbpZeroTemplate.Core/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.EntityFrameworkCore/MyCompanyName.AbpZeroTemplate.EntityFrameworkCore.csproj", "src/MyCompanyName.AbpZeroTemplate.EntityFrameworkCore/"]
COPY ["src/MyCompanyName.AbpZeroTemplate.GraphQL/MyCompanyName.AbpZeroTemplate.GraphQL.csproj", "src/MyCompanyName.AbpZeroTemplate.GraphQL/"]
RUN dotnet restore "src/MyCompanyName.AbpZeroTemplate.Web.Public/MyCompanyName.AbpZeroTemplate.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/MyCompanyName.AbpZeroTemplate.Web.Public"
RUN dotnet build "MyCompanyName.AbpZeroTemplate.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCompanyName.AbpZeroTemplate.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCompanyName.AbpZeroTemplate.Web.Public.dll"]
