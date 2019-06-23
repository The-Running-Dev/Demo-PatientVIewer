## Patient Viewer

A Responsive UI demo application build with ASP.NET Core MVC/WebAPI on top of .NET Core 2.2.

Demo: https://patientviewer.azurewebsites.net

## Running Locally

### Requirements
- .NET Core 2.2. https://dotnet.microsoft.com/download/dotnet-core/2.2

In PowerShell or Bash

1. Clone the repository:

    ```git clone https://github.com/The-Running-Dev/Demo-PatientVIewer```

2. Run the application:

    ```dotnet run -p PatientViewer.Web```

3. Access the application:

    The MVC application can be assessed at http://localhost:5000/

    The WebAPI for the Patients is at http://localhost:5000/api/patient

## Running Tests
In PowerShell or Bash

1. Complete the steps above in "Running Locally"
3. Run the tests:

    ```dotnet test```

## Project Structure and Rational

### PatientViewer.Bootstrapper
Encapulates the dependency resolver used for dependeny injection in the .NET projects. This is a separte project so the rest of the projects are not tied to a specific dependency injection framework. The current implementation is based on ```StructureMap```.

### PatientViewer.Data
Encapsulates the data models, interfaces and extensions used within ```PatientViewer.Repository```, ```PatientViewer.Service```, ```PatientViewer.Tests``` and ```PatientViewer.Web```. Here you will find the ```Patient``` model.

### PatientViewer.Repository
Encapsulates the data access for the application. Implements the reading of the data from the CSV file and memory caching.

### PatientViewer.Service
Encapsulates the business logic for accessing the data. Currently only provides the implementation of a single ```PatienService```.

### PatientViewer.Tests
Encapsulates all tests for ```PatientViewer.Data```, ```PatientViewer.Repository```, ```PatientViewer.Service``` and ```PatientViewer.Web```. Implements test for the ```StringExtensions```, ```PatientRepository```, ```RepositoryCache```, ```PatientService```, and the ```HomeController```, and ```PatientController```. ```NUnit``` is used as the testing framwork, with the help of ```Moq``` for mocking. Test setup is abstracted in the ```TestsBase``` class that acts as the setup for all tests.

### PatientViewer.Web
Encapsulates access and display to the patients through a MVC application, and a single WebAPI Controller in ```PatientController```. The views are split into the ```_Layout.cshtml``` with ```AppHeader.cshtml``` and ```SideBar.cshtml``` partials. ```Libman``` is used to manage the client side librarie, with a single entry for ```font-awesome```.

### Deployment
The MVC/WebAPI application is setup to deploy through an ```Azure Pipeline``` every time there is code committed to this GitHub repository. The Angular application is deployed through a ```Web Deploy``` profile.

#### Technologies
* .NET Core 2.2 (https://dotnet.microsoft.com/) for the MVC/WebAPI application and supprting code