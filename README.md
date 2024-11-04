# E-Commerce Service Architecture Demo

This project has been created to implement a simple e-commerce microservice architecture. The project is developed using ASP.NET Core and Entity Framework Core. API documentation is provided with Swagger, and the application is containerized with Docker.

## Table of Contents

- [Installation](#installation)
- [Technologies](#technologies)
- [Architectural Decisions](#architectural-decisions)

## Installation

### Requirements

- .NET 8.0 SDK
- SQL Server (Docker or Local)
- Docker (optional)

### Cloning the Project

```bash
git clone https://git.codebie.com/tg-workshop/4U8v9HNL2RapHA7g.git
cd 4U8v9HNL2RapHA7g
```

### Installing Packages
```bash
dotnet restore
```

### Database Configuration

The project is configured to use a SQL Server database. For me I use sqlserver localhost with Docker image. If you don't want use docker, set your connectionstring in appsettings.json. 

```json
{
  "ConnectionStrings": {
    "DefaultConnection": " Server=(localdb)\\mssqllocaldb;Database~=ECommerceDb;Trusted_Connection=false;"
  }
}
```

If you want to use Docker, you can run the following command in terminal to start a SQL Server instance:
```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=StrongPassword123!' -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server:2022-latest
```

### Database Migration
To create and apply the initial database migrations, run the following commands:
```bash
dotnet ef migrations add InitialCreate --project ECommerceService.Infrastructure --startup-project ECommerceService.API

dotnet ef database update --project ECommerceMicroservice.Infrastructure --startup-project ECommerceMicroservice.API
```

### Running with Docker

To run the project using Docker, follow these commands:
- Start Docker
- Run the project via Docker with the following command:
```bash
  docker-compose up --build
  ```

## Technologies

- ASP.NET Core 8.0
- Entity Framework Core
- Swagger
- Docker
- SQL Server

## Architectural Decisions
- You can read the architectural decisions made during the development of the e-commerce microservice in the [Design Choices](DesignChoices.md) document.

## Potential Features
- UnitofWork Pattern
- Unit tests
- Redis Cache
- Authentication and Authorization


if you have any questions, please feel free to ask. 
Note: Some comments were made with the help of AI. I hope it helps you.

https://github.com/tahakocal
Mail : tahakcal@gmail.com

Thanks for reading.
