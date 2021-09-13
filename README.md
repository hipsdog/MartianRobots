# .NET Martian Robots

.NET Core MVC web application that recieves a martian robots input and returns the output.

The application is deployed on Azure: [https://martialrobots.azurewebsites.net/](https://martialrobots.azurewebsites.net/)

## Components
- [MVC application](https://github.com/hipsdog/MartialRobots/tree/master/MartialRobots) - MVC .Net Core Web application
- [Martial robots engine](https://github.com/hipsdog/MartialRobots/tree/master/MartialRobots.Engine) - Input Parser and execution logic
- [Application domain](https://github.com/hipsdog/MartialRobots/tree/master/MartialRobots.Domain) - Domain entities, repository contracts/interfaces
- [Application infrastructure](https://github.com/hipsdog/MartialRobots/tree/master/MartialRobots.Infrastructure) - ORMs, Data access, repository implementation
- [Tests](https://github.com/hipsdog/MartialRobots/tree/master/MartialRobots.Test) - xUnit test sample

## Usage
CLI:
```
dotnet ef migrations add NewMigration --project MartialRobots.Infrastructure

dotnet ef database update
```
Launch with visual studio 2019

## Requirements
- visual studio 2019
- .NET Core 5.0
