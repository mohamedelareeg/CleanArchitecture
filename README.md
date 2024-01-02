# Clean Architecture - .NET Core 8

<p align="center">
  <a href="https://github.com/mohamedelareeg/CleanArchitecture/actions/workflows/main.yml">
    <img src="https://github.com/mohamedelareeg/CleanArchitecture/actions/workflows/main.yml/badge.svg" alt="Build Status">
  </a>
  <a href="https://github.com/mohamedelareeg/CleanArchitecture/releases">
    <img src="https://img.shields.io/github/v/release/mohamedelareeg/CleanArchitecture" alt="Release">
  </a>
  <a href="https://github.com/mohamedelareeg/CleanArchitecture/issues">
    <img src="https://img.shields.io/github/issues/mohamedelareeg/CleanArchitecture" alt="Issues">
  </a>
  <a href="https://opensource.org/licenses/MIT">
    <img src="https://img.shields.io/badge/License-MIT-blue.svg" alt="License">
  </a>
</p>

## Overview

This repository serves as a hands-on learning experience for Clean Architecture principles in .NET Core. It organizes the codebase into distinct layers for scalability, maintainability, and separation of concerns.

## Project Architecture

### 1. CleanArchitecture.Domain

The heart of the application, [CleanArchitecture.Domain](./CleanArchitecture.Domain), holds the domain entities and business logic. It represents the core of your application and remains independent of any external frameworks.

### 2. CleanArchitecture.Application

[CleanArchitecture.Application](./CleanArchitecture.Application) encapsulates application-specific business rules, use cases, and application services. It acts as a mediator between the domain layer and the infrastructure layer.

### 3. CleanArchitecture.Infrastructure

[CleanArchitecture.Infrastructure](./CleanArchitecture.Infrastructure) contains implementation details that are external to the application. It includes data access, external services, and other infrastructure concerns.

### 4. CleanArchitecture.Identity

[CleanArchitecture.Identity](./CleanArchitecture.Identity) focuses on user identity and authentication aspects, handling user-related functionalities.

### 5. CleanArchitecture.Persistence

The [CleanArchitecture.Persistence](./CleanArchitecture.Persistence) project deals with data storage and retrieval, using technologies such as Entity Framework Core to interact with the database.

### 6. CleanArchitecture.Api

[CleanArchitecture.Api](./CleanArchitecture.Api) serves as the entry point for the Web API application. It utilizes the Clean Architecture principles to handle incoming HTTP requests and coordinate actions across different layers.

### 7. CleanArchitecture.MVC

[CleanArchitecture.MVC](./CleanArchitecture.MVC) represents the MVC (Model-View-Controller) layer, handling the presentation logic for the user interface. It interacts with the application layer to retrieve and display data.

## Learn More

Ready to dive deeper into Clean Architecture? Check out the following resources:

### Books

1. [Clean Architecture: A Craftsman's Guide to Software Structure and Design](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164) by Robert C. Martin
   - An in-depth guide by Uncle Bob himself, exploring the principles and patterns of Clean Architecture.

2. [Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215) by Eric Evans
   - A classic book on Domain-Driven Design, offering insights into designing complex systems.


### Articles and Blogs

5. [Exploring Clean Architecture in ASP.NET Core](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture) on Microsoft Docs
   - Microsoft's guide on implementing Clean Architecture in ASP.NET Core applications.

6. [The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) by Robert C. Martin
   - Uncle Bob's blog post that introduced the Clean Architecture concept.

### Community and Forums

7. [Clean Coders](https://cleancoders.com/)
   - An online community and platform by Robert C. Martin, offering videos, articles, and discussions on clean code and architecture.

8. [Stack Overflow - Clean Architecture](https://stackoverflow.com/questions/tagged/clean-architecture)
   - Explore questions and discussions related to Clean Architecture on Stack Overflow.

Remember, the best way to learn is by doing. Feel free to explore the code in each layer and experiment with building your own features following the Clean Architecture principles!


## Features

1. **.NET Core 8:**
   - Utilizes the latest version of .NET Core for enhanced performance and features.

2. **FluentValidation:**
   - Integrates FluentValidation for robust input validation and improved request handling.

**Learn More:**
[FluentValidation Documentation](https://fluentvalidation.net/)

3. **Mediator:**
   - Implements the Mediator pattern for efficient communication between components.

**Learn More:**
[MediatR Documentation](https://github.com/jbogard/MediatR)

4. **AutoMapper:**
   - Uses AutoMapper for simplified object-to-object mapping.

**Learn More:**
[AutoMapper Documentation](https://docs.automapper.org/)

5. **CQRS (Command Query Responsibility Segregation):**
   - Adopts the CQRS pattern for a clear separation of concerns between commands and queries.

**Learn More:**
[CQRS Pattern Overview](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

6. **Entity Framework Core:**
   - Leverages Entity Framework Core for data access and database management.

**Learn More:**
[Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)

7. **Serilog:**
   - Incorporates Serilog for structured logging and easy log analysis.

**Learn More:**
[Serilog Documentation](https://serilog.net/)

8. **JWT (JSON Web Tokens):**
   - Implements JWT for secure authentication and authorization.

**Learn More:**
[JWT Introduction](https://jwt.io/introduction/)

9. **Authorization:**
   - Integrates authorization mechanisms to control access to different parts of the application.

**Learn More:**
[ASP.NET Core Authorization](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)

10. **Globalization:**
    - Supports globalization for multi-language and culture-specific content.

**Learn More:**
[Globalization and Localization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization)

11. **Dependency Injection:**
    - Utilizes the built-in dependency injection in .NET Core for managing application components.

**Learn More:**
[Dependency Injection in .NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)

## Learning Clean Architecture

If you're new to Clean Architecture and .NET Core, follow these steps to get started:

1. **Understand the Layers:**
   - Explore the [CleanArchitecture.Domain](./CleanArchitecture.Domain), [CleanArchitecture.Application](./CleanArchitecture.Application), and [CleanArchitecture.Infrastructure](./CleanArchitecture.Infrastructure) layers to grasp the separation of concerns.

2. **Study CQRS:**
   - Dig into the CQRS pattern implemented in this project to understand the benefits of separating command and query responsibilities.

3. **Explore Dependency Injection:**
   - Investigate how dependency injection is used in .NET Core within the context of this project.

**Learn More:**
[Dependency Injection in .NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)

4. **Read the [CleanArchitecture.Api](./CleanArchitecture.Api) and [CleanArchitecture.MVC](./CleanArchitecture.MVC) Projects:**
   - Analyze the entry points of the application and understand how they interact with the underlying layers.

5. **Experiment with Features:**
   - Modify or add features to see how changes propagate through the application layers while adhering to Clean Architecture principles.

## Deployment

To deploy the application, follow the deployment instructions in the [Deployment](#deployment) section.

## Continuous Integration / Continuous Deployment (CI/CD)

This project is configured for CI/CD with [GitHub Actions](https://github.com/features/actions). The workflow is triggered on each push to the main branch, running build and test tasks.

### Docker

Run the application in Docker containers using Docker Compose:

1. **Build and run the Docker containers:**

    ```bash
    docker-compose up -d
    ```

**Related Repositories:**
- [Docker Documentation](https://docs.docker.com/)

2. **Access the Web API:**

   - The API will be accessible at [http://localhost:5000](http://localhost:5000).
   
3. **Access the MVC application:**

   - The MVC application will be accessible at [http://localhost:5001](http://localhost:5001).

4. **Stop the containers:**

    ```bash
    docker-compose down
    ```

### CI/CD Pipeline

The CI/CD pipeline is automatically triggered on each push to the main branch. It includes the following steps:

1. **Build:**
   - Builds the application, ensuring the code compiles successfully.

2. **Test:**
   - Runs automated tests to verify the integrity of the codebase.

3. **Publish:**
   - Publishes the application, preparing it for deployment.

4. **Deploy:**
   - Deploys the application to the specified environment.

**Learn More:**
[GitHub Actions Documentation](https://docs.github.com/en/actions)

Feel free to customize the CI/CD workflow in the `.github/workflows` directory based on your deployment needs.

## Usage

This Web API provides a basic structure adhering to Clean Architecture. Customize it based on your specific application needs.


## Contributing

1. Fork the project.
2. Create a new branch: `git checkout -b feature/my-feature`.
3. Make changes and commit them: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin feature/my-feature`.
5. Open a pull request.

**Related Repositories:**
- [Clean Architecture Contribution Guidelines](https://github.com/mohamedelareeg/CleanArchitecture/blob/main/CONTRIBUTING.md)

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/mohamedelareeg/CleanArchitecture/blob/main/LICENSE) file for details.

**Related Repositories:**
- [MIT License Information](https://opensource.org/licenses/MIT)
