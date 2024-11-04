# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY ECommerceMicroservice.Application/*.csproj ./ECommerceMicroservice.Application/
COPY ECommerceMicroservice.API/*.csproj ./ECommerceMicroservice.API/
COPY ECommerceMicroservice.Domain/*.csproj ./ECommerceMicroservice.Domain/
COPY ECommerceMicroservice.Infrastructure/*.csproj ./ECommerceMicroservice.Infrastructure/

RUN dotnet restore

COPY ECommerceMicroservice.Application/. ./ECommerceMicroservice.Application/
COPY ECommerceMicroservice.API/. ./ECommerceMicroservice.API/
COPY ECommerceMicroservice.Domain/. ./ECommerceMicroservice.Domain/
COPY ECommerceMicroservice.Infrastructure/. ./ECommerceMicroservice.Infrastructure/

WORKDIR /app/ECommerceMicroservice.API
RUN dotnet publish -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/ECommerceMicroservice.API/out ./
ENTRYPOINT ["dotnet", "ECommerceMicroservice.API.dll"]
