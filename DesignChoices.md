# Design Choices for E-Commerce Microservice

## Overview

This document outlines the architectural decisions made during the development of the e-commerce microservice. The project is structured into four distinct layers: API, Infrastructure, Domain, and Application. Each layer has specific responsibilities, promoting a clean separation of concerns and adherence to best practices.

## Layer Structure

### 1. API Layer
- **Responsibilities**: The API layer serves as the entry point for external clients. It handles incoming requests, manages routing, and provides responses.
- **Components**:
    - **ExceptionHandlingMiddleware**: A custom middleware to catch exceptions globally and return appropriate HTTP responses.
    - **Controllers**: Each controller is responsible for handling specific entities (e.g., Products, Categories). All controllers are equipped with Swagger documentation to facilitate API exploration and testing.

### 2. Infrastructure Layer
- **Responsibilities**: The Infrastructure layer is responsible for data access and external service interactions.
- **Components**:
    - **DbContext**: Utilizes Entity Framework Core for database interactions, providing a mapping between the database and application entities.
    - **Repositories**: Implementations for Product and Category repositories, encapsulating data access logic and providing an abstraction layer over the DbContext.

### 3. Domain Layer
- **Responsibilities**: The Domain layer defines the core business entities and domain logic. It represents the fundamental concepts of the application.
- **Components**:
    - **Entities**: Contains classes that represent the domain objects, such as `Product` and `Category`. These classes encapsulate business rules and behaviors.

### 4. Application Layer
- **Responsibilities**: The Application layer acts as a bridge between the API and Domain layers, orchestrating application logic and managing data transfer.
- **Components**:
    - **DTOs (Data Transfer Objects)**: Classes that represent the data structure used for communication between layers. DTOs ensure that only relevant data is passed to and from the API layer.
    - **Services**: Contains business logic and coordinates operations involving multiple repositories or entities.

## Architectural Decisions

- **SOLID Principles**: The design adheres to SOLID principles, ensuring that each class has a single responsibility, promoting maintainability and testability.
- **Dependency Injection**: The solution employs dependency injection to manage service lifetimes and dependencies, facilitating loose coupling between components.
- **Error Handling**: Centralized error handling through middleware improves the user experience by providing consistent error responses.
- **Documentation**: Swagger is integrated for API documentation, allowing users to explore the available endpoints and their usage.

## Database
- Utilizes SQL Server for data storage, with Entity Framework Core for ORM capabilities.
- Seed data implemented for initial product entries.

## Bonus Implementations
- **Dockerization**: The application can be containerized for consistent deployment across different environments.
- **Data Validation**: Additional validation logic for entities has been implemented to ensure data integrity before persistence.

## Conclusion

This architectural design aims to create a scalable, maintainable, and testable e-commerce microservice. The separation of concerns among layers allows for easier management and future enhancements.

