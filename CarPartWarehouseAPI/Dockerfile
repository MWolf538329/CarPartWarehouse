FROM mcr.microsoft.com/dotnet/sdk:8.0-azurelinux3.0-amd64 AS build
WORKDIR /app

COPY ./Main ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-azurelinux3.0-distroless-extra
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "CarPartWarehouseAPI.dll"]