# Contactinformation-API

This is an API for maintaining contact information. It exposes basic functionality for creating, reading, updating and deleting contacts.

## Project Structure
Given below is the list of project in this solution and a one liner description for the same

**1. ContactInformation.Api** -
This project is the entrypoint to the WEB API and houses the controllers via which users can access data.

**2. ContactInformation.BLL.Interface** -
This project has all the contracts/interfaces/methods via which the consumer (API layer in this case) would interact with the business layer. The reason for interacting with Businesslogic layer via interface is to support loose coupling across layers. This way, we address separation of concerns making code more maintainable and testable.

**3. ContactInformation.BLL**-
This project has all the concrete implementation of the BLL Interface.

**4. ContactInformation.DAL.Interface**-
This project has contracts/interfaces/methods via which the consumer(Business logic layer in this case) would interact with the Database layer. 

**5. ContactInformation.DAL**-
This project has concrete implementation for the Data access layer interface.

**6. ContactInformation.Entities**-
This project houses all the entities of the application.

**7. ContactInformation.Utilities**-
This project will have all the re-usable utility methods.

**8. ContactInformation.Common**-
This project has all the objects/functionality that would address cross cutting concerns i.e. functionality that would be needed by multiple layers.

**9. ContactInformation.UnitTest.Api**-
Unit test project for testing API layer

**10. ContactInformation.UnitTest.BLL**-
Unit testing project for testing the Business logic layer.

## Pre-requisites
- Visual Studio 2015 or above
- .Net Framwork 4.6 or above

## How to run the application
1. Build the solution once in visual studio so that all the nuget packages/dependencies are resolved.
2. You can then run the application using visual studio.
3. The project is integrated with swagger UI. You can navigate to below URL for exploring the methods exposed via the API
http://localhost:52261/swagger/ui/index

Note - The port number in above URL might vary on your machine.


## Important libraries nugets used
1. FakeItEasy - Mocking framework used for mocking data in unit tests
2. Autofac - IoC container used for dependency injection/resolution.
3. Swashbuckle - Used for API documentation(Swagger UI).


