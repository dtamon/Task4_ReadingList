# Reading List

App allowing the user to keep a list of books planned to read, the order in which they will be read.

## Features
- CRUD on Books and Authors tables
- Displaying the list of all books and authors and filtering/sorting them
- Reordering the list of books by dragging and dropping table rows with the symbol in the first column of the table. To save the current order in database it is required to click `Save Order` button to update values in position column
- Books that are marked as read should contain null value in field `Position`, newly added books to the list have Position = 0, you can drag them to the desired position and click `Save Order` to update the `Position` values. Books that are added as Already Read will be automatically updatet to Position = null on `Save Order` click

## Configuration
#### 1. The Database is hosted on [freeasphosting.net](https://freeasphosting.net/) so there is no need to generate the schema on the local server. It should contain some sample records by default. It may take a few seconds to load data after starting the project
#### 1a. In case of problems with database, change your connection string in [appsettings.json](https://github.com/dtamon/Task4_ReadingList/blob/master/Task4_ReadingList.API/appsettings.json),
````json 
"ConnectionStrings": {
    "connection": "your connection string"
  }, 
````    
#### generate schema by running `update-database` command in Package Manager Console (make sure you've picked `Task4_ReadingList.DataAccess` as default project) ![PMC](https://i.imgur.com/PfmyK8M.png) 
#### database should be filled automatically with [ReadingListSeeder](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.DataAccess/Seeder) which contains same data as [SampleBooks.sql](https://github.com/dtamon/Task4_ReadingList/blob/master/SampleBooks.sql) script
#### 2. The way I run the project is to open whole solution in Visual Studio and run `Task4_ReadingList.API` project there, open `Task4_ReadingList.Client` frontend project in Visual Studio Code and start it with command `npm start` from terminal
#### 3. Before the first launch it may be required to install react libraries (`react`, `react-icons`, `react-beautiful-dnd` and `react-router-dom`) by running commands `npm i <name_of_library>` in terminal



## Architecture

- Solution contains 4 layers ([Repository](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.DataAccess), [Service](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.Service), [API](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.API) and [Frontend](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.Client))
- I used Entity Framework Core for easy communication with database
- For validation purpose I used [Fluent Validation](https://docs.fluentvalidation.net/en/latest/) library
- For styling I used [Bootstrap](https://getbootstrap.com/) library
- [Controllers](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.API/Controllers) job is to communicate between [Frontend](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.API) and [Services](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.Service/Services)
- [Services](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.Service/Services) job is to call [Repositories](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.DataAccess/Repositories) to access data that will be cast to [DTOs](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.Service/Dto) using [AutoMapper](https://automapper.org/), and the other way to cast DTOs to [Entity Models](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.DataAccess/Entities) ready to be saved in database.
- [Repositories](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.DataAccess/Repositories) job is to get needed data from database using LINQ, each repository corresponds to a table from the database
- [DTOs](https://github.com/dtamon/Task4_ReadingList/tree/master/Task4_ReadingList.Service/Dto) are models containing data intended for display on the frontend

## Database (MS SQL Server)
#### Database is hosted on [freeasphosting.net](https://freeasphosting.net/)
### Database schema
![Database Schema](https://i.imgur.com/Tae3gRn.png)
