# Message Management Service
This solution was developed using .NET 6 and Visual Studio 2022.
The aim is to demonstrate knowledge on .NET, C#, API design and architecture.
Key concepts: NET API, SOLID, HTTP/HTTPS, Repository Pattern, Request Validation.

## How to run
* Open the solution on Visual Studio and use the built-in tools to compile and execute the code.
* Alternatively, you can use the `dotnet CLI` to restore the dependencies, build and run the solution.

Once the application is up and running, a Swagger page will automatically open.
You can use the Swagger UI to easily perform requests and test the API.
Alternatively, you may target the API on port 7155.

## Packages used
* Swashbuckle.AspNetCore (for Swagger),
* FluentValidation.AspNetCore (for validating requests),
* xUnit, xUnit.Runner.VisualStudio, Coverlet.Collector, Microsoft.NET.Test.Sdk (for unit testing)