## Patient Viewer

A Responsive UI Demo Application

The application consists of two separate applications

- A ASP.NET Core MVC/WebAPI built with .NET Core 2.2

- A Angular application built with Angular 8

#### [MVC Demo](https://patientviewer.azurewebsites.net/)

#### [Angular Demo](https://patientviewer-ng.azurewebsites.net/)

## Running Locally

### Requirements
- .NET Core 2.2 [Download](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- NodeJS 12 [Download](https://nodejs.org/en/download/current/)

### Steps
1. Clone this repository
2. Install the Node dependencies
```
npm run setup
```
3. Run the applications
```
npm run start
```
#### The MVC application can be assessed at http://localhost:5000/
#### The WebAPI for the Patients at http://localhost:5000/api/patient
#### The Angular UI will open a browser to http://localhost:4200

#### Client (Angular)
1. Change directory to client: ```cd .\client```
2. Install the dependencies: ```npm install```
3. Run the client: ```ng serve```
4. Browse to ```http://localhost:4200```

#### Technologies
* [Angular] (https://angular.io) for demo client consumer
* [TypScript](http://www.typescriptlang.org/) for strongly typed JavaScript