# OData (Open OData Protocol) usage with ASP.NET Core 2.2 application for Supercharging your Web APIs


## Required Nuget Packages

 * Microsoft.AspNetCore.App Version="2.2.0" 
 * Microsoft.AspNetCore.OData" Version="7.1.0" 
 * Microsoft.AspNetCore.OData.Versioning.ApiExplorer" Version="3.2.0" 
 * Microsoft.EntityFrameworkCore.InMemory" Version="2.2.6"
 


## 4 Steps to configure OData in .NET Core Web API project

* Step 1: Install OData Nuget Package Microsoft.AspNetCore.OData in your existing/ new project.

* Step 2: In Startup.cs file and add in this line of code in your ConfigureServices Function & add the reference:

           services.AddOData(); 

* Step 3: Enable the dependency injection support for ALL HTTP routes. In Startup.cs let’s go to the Configure function and add these two lines of code:

          app.UseMvc(routeBuilder => {
 
                      routeBuilder.EnableDependencyInjection();
                      
                      // Add OData Functionalities
                      
                      routeBuilder.Expand().Select().OrderBy().Filter();
          });
          
* Step 4: Add [EnableQuery()] annotation on top of your Action Method for your endpoint where you want to implement OData query feature.:



## OData Endpoints with different supported filters (Expand(), Select(), OrderBy(), Filter())

* Query the metadata

GET http://localhost:5000/odata/$metadata

* Query List of Books

GET http://localhost:5000/odata/Books

* Query Sepecific Book

GET http://localhost:5000/odata/Books(2)

* Create a New Book

POST http://localhost:5000/odata/Books

* Applying Price filter

GET http://localhost:5000/odata/Books?$filter=Price le 50

* Applying Expand

GET http://localhost:5000/odata/Books?$filter=Price le 50&$expand=Press($select=Name)

* Applying Select

GET http://localhost:5000/odata/Books?$filter=Price le 50&$expand=Press($select=Name)&$select=ISBN


