# API retrieve a list of countries


- SharedKernel project with common Domain-Driven Design abstractions.
- Domain layer with a Country entity.
- Application layer with abstractions for:
    - CQRS
    - Caching
    - Cross-cutting concerns (logging, caching, validation)
- Infrastructure layer with:
    - SQL, EF Core and Dapper for Simple SQL, Caching, Repositories, 
- Seq for searching and analyzing structured logs
    
- Testing projects
    - Unit testing
    - Integration testing
    - Functional testing
- Yaml fine for CI/CD pipeline
  - contains workflow file to build, test and publish.
  - Whats is missing is adding a deployment target
