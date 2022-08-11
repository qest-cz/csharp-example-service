FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY Qest.Example.Core/Qest.Example.Core.csproj Qest.Example.Core/
COPY Qest.Example.Application/Qest.Example.Application.csproj Qest.Example.Application/
COPY Qest.Example.Infrastructure/Qest.Example.Infrastructure.csproj Qest.Example.Infrastructure/
COPY Qest.Example.Service.Interface/Qest.Example.Service.Interface.csproj Qest.Example.Service.Interface/
COPY Qest.Example.Service/Qest.Example.Service.csproj Qest.Example.Service/

WORKDIR Qest.Example.Service
RUN dotnet restore

WORKDIR /src
COPY Qest.Example.Core/ Qest.Example.Core/
COPY Qest.Example.Application/ Qest.Example.Application/
COPY Qest.Example.Infrastructure/ Qest.Example.Infrastructure/
COPY Qest.Example.Service.Interface/ Qest.Example.Service.Interface/
COPY Qest.Example.Service/ Qest.Example.Service/

WORKDIR Qest.Example.Service
RUN dotnet publish -c Release --no-restore -o /app

FROM base AS final
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Qest.Example.Service.dll"]
