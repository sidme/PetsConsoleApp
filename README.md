Pets Console App
----------------
Version: 0.1.1

Pets console app is a C# console application to demonstrate consuming an external API, producing list of pet names sorted alphabetically and grouped by pet's owner's gender.



Getting Started
---------------


To get started with this application you will need:
1. Visual Studio IDE - Community Edition of Visual Studio 2017 can be downloaded free from below URL:
    https://www.visualstudio.com/downloads/


Following are instructions to get started with this application:

1. Download or clone Github repo.
2. Open solution from local repo by double clicking PetsConsoleApp.sln file. This will open solution in Visual Studio. Solution has two projects (See Project Summary below).
3. Build solution - this ensure all necessary NuGet packages are downloaded and that there are no errors.
4. Run application in Visual Studio by pressing Ctrl+F5



Projects Summary
----------------

1. PetsConsoleApp - is the main application project. Contains C# console app entry point, all business logic and data access components.
2. PetsConsoleApp.Tests - contains all units test for PetsConsoleApp main project.


Solution Structure
------------------
Below defines how application code is structured and interacts with various layers.

External API -> API Layer -> Business Logic Layer -> Client/Console Application


Design Considerations
---------------------
1. Classes in main project are organised using folders. In bigger projects, these folders could represent separate class library projects.
2. Unit tests do not cover all possible scenarios.
3. Used AutoFac as IoC container.
4. ApiClient.cs is abstract class containing code to interact with API. 
5. PetOwnerService - API Layer
    1. Implements IPetOwnerService interface to get data from API.
    2. Inherits from ApiClient abstract class.
6. PetOwnerLogic - Business Logic Layer
    1. Implements IPetOwnerLogic interfade to get data from Service layer.
    2. Responsible to transfor input (from PetOwnerService) into object required by Program.Main() consumer.
7. Program - Client/Consumer/UI
    1. Registers IOC Container
    2. Interacts with Business Logic Layer to get data
    3. Checks for null or empty list.
    4. Displays output in console window.




NuGet Packages
---------------------------------

1. AutoFac (Ver - 4.6.2)- is an IOC container. Manages Dependency Injection for the project.
2. Newtonsoft.Json (Ver - 11.0.2) - To serialise/deserialise JSON payload.
3. RhinoMocks (Ver - 3.6.1) - For unit testing


Feedback
---------
To raise any issue or to start discussion please visit https://github.com/sidme/PetsConsoleApp/issues
