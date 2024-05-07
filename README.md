# TodoApp

This is a simple Todo application built with ASP.NET Core Web API and Angular.

## Requirements

Before running the application, ensure you have the following dependencies installed:

Node.js: Download

.NET SDK: Download

Angular CLI: Install globally via npm by running npm install -g @angular/cli

Bootstrap: npm install bootstrap

## Running unit tests
This project includes unit tests for the API using xUnit. Follow the instructions below to run the tests:

Navigate to the TodoAPI.Tests directory: TodoAPI.Tests
Run the tests using the "dotnet test" command

This command will discover and execute all the unit tests within the project. You should see the test results displayed in the terminal.

## Further help

To get more help on this project, send an email to parthbirla04@gmail.com

## Config

The API runs on "https://localhost:7052" which can be changed from Properties-> Launch.Json -> applicationURL

## Note

If the application url is changed, ensure the apiUrl in TodoApp-UI -> src -> config.ts is updated accordingly 
