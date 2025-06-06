FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY CarCompaniesApplication.API/CarCompaniesApplication.API.csproj CarCompaniesApplication.API/
COPY CarCompaniesApplication.BLL/CarCompaniesApplication.BLL.csproj CarCompaniesApplication.BLL/
COPY CarCompaniesApplication.DAL/CarCompaniesApplication.DAL.csproj CarCompaniesApplication.DAL/
RUN dotnet restore CarCompaniesApplication.API/CarCompaniesApplication.API.csproj

COPY . .
WORKDIR /src/CarCompaniesApplication.API
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CarCompaniesApplication.API.dll"]
