## Hangfire Demo
__Hangfire__: An easy way to perform background processing in .NET and .NET Core applications.
I created this demo in Dotnet 7, to discover Hangfire's main features and usability.

### Hangfire components
- __Hangfire client__
These are the actual libraries inside our application. The client creates the job, serializes its definition, and makes sure to store it into our persistent storage.
- __Hangfire storage__
This is our database. It uses a couple of designated tables that Hangfire creates for us. It stores all the information about our jobs – definitions, execution status, etc. Hangfire supports both RDBMS and NoSQL options, so we can choose which one works for our project. By default, it uses SQL Server, but any other supported option is also easy to configure.
- __Hangfire server__
The server has the task of picking up job definitions from the storage and executing them. It’s also responsible for keeping our job storage clean from any data that we don’t use anymore. The server can live within our application, or it can be on another server. It always points to the database storage so its location doesn’t play a role, but this diversity can be very useful.

https://code-maze.com/hangfire-with-asp-net-core/ 


<img src="https://code-maze.com/wp-content/uploads/2021/05/HangfireArchitecture-1.png">


### Types of Hangfire Jobs

There are different types of jobs in Hangfire, such as:

* __Fire-and-forget jobs__: 
These are executed only once and almost immediately after creation23.
* __Delayed jobs__: 
These are executed only once, but not immediately, after a specific time interval23.
* __Recurring jobs__: 
These are executed many times on the specified CRON schedule23.
* __Continuations__: 
These are executed when their parent job has been finished2.
