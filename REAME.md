# Alsideeq Bookstore Api

## Prerequisites

- Install dotnet core 3.1 SDK from <https://dotnet.microsoft.com/download/dotnet-core/3.1>

- Install MySql Workbench to connect to the AWS DB alsideeq-bookstore-instance.clslxbbfn4dw.us-east-2.rds.amazonaws.com find instructions here: <https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_ConnectToInstance.html>
- Install Postman to exercise api calls <https://www.postman.com/>
  
## Run project

- run ```dotnet build``` to build project from command prompt or powershell on windows machine, or from command line on mac
- run ```dotnet run --no-build``` command to run the app
- To exercise apis you can call GET localhost:5000//Account/Users from postman to verify app is running