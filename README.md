## Patient Viewer

A Responsive UI Demo Application

The project consists of two separate applications:

- A ASP.NET Core MVC/WebAPI built with .NET Core 2.2

- A Angular application built with Angular 8

#### MVC Demo: https://patientviewer.azurewebsites.net

#### Angular Demo: https://patientviewer-ng.azurewebsites.net

## Running Locally

### Requirements
- .NET Core 2.2 https://dotnet.microsoft.com/download/dotnet-core/2.2
- NodeJS 12 https://nodejs.org/en/download/current/

### Steps
In PowerShell or Bash

1. Clone the repository:

    ```git clone https://github.com/The-Running-Dev/Demo-PatientVIewer```

2. Install the Node dependencies:

    ```npm run setup```

3. Run the applications:

    ```npm run start```
4. Access the applications:

    The MVC application can be assessed at http://localhost:5000/

    The WebAPI for the Patients is at http://localhost:5000/api/patient

    The Angular UI will open a browser to http://localhost:4200

## Running Tests
In PowerShell or Bash

1. Complete the steps above in "Running Locally"
3. Run the tests:

    ```npm run test```

## Project Structure and Rational

### ClientApp
The Angular application. Data is provided though the WebAPI controller from PatientViewer.Web.

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
* Angular 8 (https://angular.io) for demo client consumer
* TypScript )http://www.typescriptlang.org/) for strongly typed JavaScript