# TaskmanagementClient

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.3.12.

## Development server

version .NET6

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## install the project
run npm i

## to generate database
Update the connection string in the TaskManagement.Server\appsettings.json file with your local sql server management connection string.


# to add login functionnality

Create a configuration for your app in the [(https://console.cloud.google.com/welcome)]. And add the URL of the Angular debug server (http://localhost:4200) as “Authorised JavaScript origin”

Get the app’s Client ID that google created for you. Copy the client ID. You will need it in further steps of this guide.

in the


for further information you can refer to this doc https://medium.com/@danilrabizo/google-authentication-in-the-angular-application-e86df69be58a

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
