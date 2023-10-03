# Clean Architecture Guide

Clean Architecture, formerly known as Onion Architecture or Hexagonal Architecture, is a software design pattern that emphasizes the separation of concerns and the independence of the core business logic from external concerns such as databases, web servers, and user interfaces. This architectural approach aims to make applications more flexible, adaptable, and testable.

## Key Principles of Clean Architecture

### 1. Dependency Inversion

In Clean Architecture, the application should depend on abstractions, not on concrete implementations. This principle dictates that the core business logic must not be tightly coupled to specific database systems, web servers, or user interface technologies. Instead, it should rely on interfaces that can be implemented by various concrete classes.

### 2. Separation of Concerns

Clean Architecture divides an application into multiple layers, each with its own distinct responsibilities. This separation enhances the clarity, maintainability, and evolution of the application. The layers include:

- Core Business Logic: Contains the most critical domain logic.
- Application: Manages use cases, orchestrates domain logic, and interfaces with external systems.
- Infrastructure: Handles external concerns such as databases, APIs, and frameworks.

### 3. Testability

Clean Architecture encourages test-driven development by ensuring that the core business logic remains decoupled from external dependencies. This design enables independent testing of the application components.

## Benefits of Clean Architecture

1. **Flexibility**: Clean Architecture makes it easier to adapt the application to changing requirements.
2. **Testability**: The separation of concerns simplifies unit testing and verification of the core business logic.
3. **Maintainability**: Clean code organization and clear responsibilities enhance code maintainability.

## Clean Architecture Rules

1. Model all business rules and entities in the Core project.
2. Ensure that all dependencies flow toward the Core project.
3. Define interfaces in inner projects, and implement them in outer projects.

## Core Project Contents

The Core project is the heart of the application and should include the following components:

- Interfaces
- Aggregates
- Entities
- Value Objects
- Domain Services
- Domain Exceptions
- Domain Events
- Event Handlers
- Specifications
- Validators
- Enums
- Custom Guards

## Infrastructure Project Contents

The Infrastructure project is responsible for handling external concerns, including:

- Repositories
- API Clients
- File System Accessors
- Emailing Implementations
- System Clock
- DbContext classes
- Azure Storage Accessors
- SMS Implementations
- Cached Repositories
- Other Services

## Web Project Contents

The Web project focuses on the user interface and includes:

- Controllers
- Razor Pages
- ViewModels
- Filters
- Model Binders
- Tag Helpers

## Shared Kernel Contents

The Shared Kernel contains components that are shared across the entire application:

- Enums
- Common Exceptions
- Common Guards
- Common Libraries
- Dependency Injection (DI)
- Logging
- Validators

This structure helps in maintaining a well-organized and maintainable application following the principles of Clean Architecture.
