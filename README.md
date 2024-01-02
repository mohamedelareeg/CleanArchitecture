# Clean Architecture - .NET Core 8

## Overview

This repository serves as a hands-on learning experience for Clean Architecture principles in .NET Core. It organizes the codebase into distinct layers for scalability, maintainability, and separation of concerns.

## Project Architecture

### 1. CleanArchitecture.Domain

The heart of the application, `CleanArchitecture.Domain`, holds the domain entities and business logic. It represents the core of your application and remains independent of any external frameworks.

### 2. CleanArchitecture.Application

`CleanArchitecture.Application` encapsulates application-specific business rules, use cases, and application services. It acts as a mediator between the domain layer and the infrastructure layer.

### 3. CleanArchitecture.Infrastructure

`CleanArchitecture.Infrastructure` contains implementation details that are external to the application. It includes data access, external services, and other infrastructure concerns.

### 4. CleanArchitecture.Identity

`CleanArchitecture.Identity` focuses on user identity and authentication aspects, handling user-related functionalities.

### 5. CleanArchitecture.Persistence

The `CleanArchitecture.Persistence` project deals with data storage and retrieval, using technologies such as Entity Framework Core to interact with the database.

### 6. CleanArchitecture.Api

`CleanArchitecture.Api` serves as the entry point for the Web API application. It utilizes the Clean Architecture principles to handle incoming HTTP requests and coordinate actions across different layers.

### 7. CleanArchitecture.MVC

`CleanArchitecture.MVC` represents the MVC (Model-View-Controller) layer, handling the presentation logic for the user interface. It interacts with the application layer to retrieve and display data.

## Features

1. **.NET Core 8:**
   - Utilizes the latest version of .NET Core for enhanced performance and features.

2. **FluentValidation:**
   - Integrates FluentValidation for robust input validation and improved request handling.

3. **Mediator:**
   - Implements the Mediator pattern for efficient communication between components.

4. **AutoMapper:**
   - Uses AutoMapper for simplified object-to-object mapping.

5. **CQRS (Command Query Responsibility Segregation):**
   - Adopts the CQRS pattern for a clear separation of concerns between commands and queries.

6. **Entity Framework Core:**
   - Leverages Entity Framework Core for data access and database management.

7. **Serilog:**
   - Incorporates Serilog for structured logging and easy log analysis.

8. **JWT (JSON Web Tokens):**
   - Implements JWT for secure authentication and authorization.

9. **Authorization:**
   - Integrates authorization mechanisms to control access to different parts of the application.

10. **Globalization:**
    - Supports globalization for multi-language and culture-specific content.

11. **Dependency Injection:**
    - Utilizes the built-in dependency injection in .NET Core for managing application components.

## Learning Clean Architecture

If you're new to Clean Architecture and .NET Core, follow these steps to get started:

1. **Understand the Layers:**
   - Explore the `CleanArchitecture.Domain`, `CleanArchitecture.Application`, and `CleanArchitecture.Infrastructure` layers to grasp the separation of concerns.

2. **Study CQRS:**
   - Dig into the CQRS pattern implemented in this project to understand the benefits of separating command and query responsibilities.

3. **Explore Dependency Injection:**
   - Investigate how dependency injection is used in .NET Core within the context of this project.

4. **Read the CleanArchitecture.Api and CleanArchitecture.MVC Projects:**
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

This command will build the Docker images and start the containers in detached mode.

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

Feel free to customize the CI/CD workflow in the `.github/workflows` directory based on your deployment needs.

## Usage

This Web API provides a basic structure adhering to Clean Architecture. Customize it based on your specific application needs.

## Contributing

1. Fork the project.
2. Create a new branch: `git checkout -b feature/my-feature`.
3. Make changes and commit them: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin feature/my-feature`.
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
