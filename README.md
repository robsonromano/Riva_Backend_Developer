# IntelSyncStarter Solution

This solution is composed of 5 projects, each responsible for a specific part of the system. Below is a description of each project and its role.

---

## Projects Overview

### 1. **IntelSyncStarter.Business**
Contains the application's business logic and service implementations.

#### Folders:
- `DataInitialization`: Contains files with the application's fake initialization data.
- `Implementations`: Classes with the implementation of the business rules (services).
- `Interfaces`: Interfaces for the services used across the application.

---

### 2. **IntelSyncStarter.Console**
Console application responsible for:
- Inserting fake data.
- Starting the CRM synchronization process.

#### Main Files:
- `appsettings.json`: Configuration file where you can set:
  - `BatchSize`: Number of records processed per batch.
  - `ParallelProcess`: Number of parallel tasks to run concurrently.
- `Program.cs`: 
  - Configures dependency injection.
  - Triggers fake data generation.
  - Starts the synchronization process.

---

### 3. **IntelSyncStarter.Domain**
Holds the core entities and enumerators used throughout the system.

#### Folders:
- `Entities`: Business models used in the application.
- `Enums`: Enumerators defined as objects so that they can be easily displayed as strings.

---

### 4. **IntelSyncStarter.Infrastructure**
Contains code related to infrastructure, such as data storage or integration with external systems.

#### Folders:
- `Implementations`: Simulated database interaction using in-memory lists.
- `Interfaces`: Repository interfaces for data access and external service interaction.

---

### 5. **IntelSyncStarter.Test**
Unit test project for the application.

#### Test Files:
- `ValidateTokenTests.cs`: Contains unit tests for token validation logic.

---

## Getting Started

To run the application:

1. Make sure all projects are included in the solution and restore dependencies.
2. Set `IntelSyncStarter.Console` as the startup project.
3. Run the application. It will generate mock data and start processing synchronization jobs in parallel.

---

## Configuration

In the `appsettings.json` file inside the `IntelSyncStarter.Console` project:

```json
{
  "BatchSize": 5,
  "ParallelProcess": 3
}
