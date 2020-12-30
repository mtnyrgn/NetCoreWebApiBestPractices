# NetCoreWebApiBestPractices# NetCoreWebApiBestPractices

What's included

.NET Core Web Api Template#v1.0.0
├── NetCoreWebApiBestPractices/         #Solution
│   ├── SolutionItems/  #Items like Nuget.Config, .gitignore
│   ├── API/            #API
│   ├── Core/  #Core
│   ├── Data/           #Data
│   ├── Service/           #Service
│   └── Test/        #Test
└── 
Starting

This project is created with layered architecture. The layer order is Core -> Data -> Service -> API

When starting a new project, the name of the solution NetCoreWepApiBestPractices should be changed in the all solution as wished.

API

API module includes Controllers, Data Transfer Objects(DTO), Database Connections (appsettings.json),Filters,Mappings, Extensions and Configurations (Startup.cs)

As an example, Product and Category controllers are created. Swagger configuration is implemented. Product, Category DTO's are created. Basic CRUD operations are included in controllers.

Database connections should be changed accordingly in appsettings.json. Startup.cs file can be used as it is.

CustomLibrary

Custom classes can be created in this module. Some extension controlling functions and similar classes added here as an example.

Core

Data modeling is made in this module. Simply tables that need to be created in the database are designed as classes. Product and Category are created as an example. 

All interfaces is created in this module because of provide strongly abstraction. For example, IRepository, IMongoRepository, IService, IUnitOfWork...etc.

Data

This module contains interfaces implementations which created in Core layer, entities configuration class, dbContext, seeds and migration files. AppDbContext will be used for the project. When creating new tables, classes and configurations should be added to the AppDbContext.

Service

The service interfaces which is created at Core layer are implemented here. All the services which are related to data models will be written in IService and Service. services are separately created as seen.

Test

Test functions added here.
