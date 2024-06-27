# Carbook

Social media web API for petrolheads. A playground for testing various things in .NET.

## Current structure:
### Carbook API
A backend API focused on cars, uses multiple projects to follow Clean Architecture. It is intended to be a portal for car fans, with the possibility of creating user accounts, adding cars, creating car events, etc. The list of planned functionalities is long and allows to test all the possibilities of the .NET libraries
### Carbook WebApp
A frontend app using Blazor. Aims to facilitate testing some of the backend functionality such as live chat - I'm treating it as a test app to familiarise myself with the absolute basics of creating Blazor Web Apps

## Key Features

- Carbook API follows a Clean Architecture approach. Also uses CQRS pattern using MediatR
- Entity Framework Core with SQLite database
- implemented Result pattern
- WIP unit tests using xUnit, NSubstitute and FluentAssertions

### Main TODOs
- authentication and authorization, first steps done using JWT tokens
- add some logging, probably with Serilog. Add ILoggerAdapter for better unit testing
- integration tests
- move database to cloud. Probably to Azure to get familiar with that provider
- GraphQL for cars browser
- something for live chat or anything that uses realtime communication
- experiment with domain events and Eventual Consistency (if not implement an Unit of Work pattern for many operations on databases)
- CONTAINERIZATION
- maybe some DevOps fun
