# .NET Martian Robots

.NET Core MVC web application that recieves a martian robots input and returns the output.

## Components
- [MVC application](https://github.com/hipsdog/MartianRobots/tree/master/MartianRobots) - MVC .Net Core Web application
- [Martian robots engine](https://github.com/hipsdog/MartianRobots/tree/master/MartianRobots.Engine) - Input Parser and execution logic
- [Application domain](https://github.com/hipsdog/MartianRobots/tree/master/MartianRobots.Domain) - Domain entities, repository contracts/interfaces
- [Application infrastructure](https://github.com/hipsdog/MartianRobots/tree/master/MartianRobots.Infrastructure) - ORM, Data access, repository implementation
- [Tests](https://github.com/hipsdog/MartianRobots/tree/master/MartianRobots.Test) - xUnit test sample

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
