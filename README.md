# Azure Voting App

Example of a real-time voting app using Microsoft Azure serverless resources (Functions, CosmosDB, SignalR).
This example contains two projects :
* The Azure Functions app at the root (.NET Core 3.1)
* The client App to use the functions in the "ClientApp" directory (Angular 9)

## Requirements

- A valid Microsoft Azure Subscription (try it for free [here](https://azure.microsoft.com/free/))
- An Azure CosmosDB resource with a Database "Votes" and a container "Votes"
- An Azure SignalR resource
- Nodejs

## Installation

- Clone the repo

- Azure Functions
  - Add the two connection strings in the application settings :
    -  CosmosDBConnection
    -  AzureSignalRConnectionString
  - Build with Visual Studio 2019 or Visual Studio Code
  - Play with the functions

- Client App
  - Open a command tool in ClientApp
  - Set the url of your functions in the file 'config.json' in the directory 'Assets'
  - Run npm install
  - Launch with ng start
