# The-Maplr-Sugar-Shack
**This project has basic backend operations for the Maplr sugar shack shop.**   

## API Functionalities

* Maple syrup catalog filterable by type : there is 3 types of maple syrup : Amber, Dark, Clear
* Product details
* Management of the cart
* Order validation

## Tech-Stack
1. .Net 6 and C#
1. Followed Clean Architecture pattern (Onion view). 
1. Applied CQRS with MediatR
1. Fluent Validation for validation in commands and queries.
1. EF Core with in memory database.
1. Unit Testing with Xunit.
1. Mocking dependencies with Moq.
1. Swagger Open API integration.

## How to Run

Please open the project from VS and start The Maplr Sugar Shack Web API project.
It seeds some initial products data to In-memory database once it's loaded.
These test data can be used in Swagger UI for testing.

![Swagger UI](https://github.com/ShamalFdo129/The-Maplr-Sugar-Shack/blob/main/Capture.JPG)


