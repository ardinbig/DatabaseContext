# DatabaseContext: A Simplified Database Connection Manager for .NET

DatabaseContext is a .NET library designed to simplify and streamline database connection management for various database providers, including:

* MySQL
* SQL Server
* PostgreSQL
* Oracle

It offers a unified and intuitive interface for initializing, configuring, and interacting with database connections.

## Key Features

* **Multi-Database Support:** Seamlessly connect to various database management systems like MySQL, SQL Server, PostgreSQL, and Oracle.
* **Singleton Pattern:** Ensures a single instance of the database connection throughout your application, promoting efficient resource utilization.
* **Effortless Initialization:** Configure database connections with a user-friendly interface for a smooth setup process.
* **Data Annotation Validation:** Enhances code reliability by validating database configuration properties using data annotations.

## Getting Started

### Prerequisites

* .NET Framework 4.8 or later
* Visual Studio 2022 (or a compatible IDE)

### Installation

1. Clone the DatabaseContext repository using Git:

   ```bash
   git clone https://github.com/ardinbig/DatabaseContext.git
   ```

2. Open the solution file (.sln) in Visual Studio.

3. Build the solution to restore the required NuGet packages.

### Usage

1. **Configure the Database Connection:**

   Create a `Database` object and set the necessary connection properties:

   ```csharp
   using DatabaseContext;

   var database = new Database
   {
       Server = "localhost",
       DbName = "your_database_name",
       User = "your_username",
       Password = "your_password",
       Port = 3306 // For MySQL connections
   };
   ```

2. **Initialize the Connection:**

   Utilize the `Connection` class to establish a connection to the database:

   ```csharp
   var connection = Connection.Instance;
   connection.DbType = DatabaseType.MySql; // Set the database type
   var dbConnection = connection.Initialize(database);
   ```

3. **Interact with the Database:**

   Employ the `dbConnection` object to perform database operations:

   ```csharp
   dbConnection.Open();
   // Execute database queries or commands here
   dbConnection.Close();
   ```

## Classes and Interfaces

### Database

This class represents the configuration details for a database connection.

```csharp
public class Database
{
    public string Server { get; set; } = "localhost";
    public string DbName { get; set; }
    public string User { get; set; }
    public string Password { get; set; } = "";
    public int Port { get; set; } = 0;
}
```

### IConnection

This interface defines the contract for initializing a database connection.

```csharp
public interface IConnection
{
    IDbConnection Initialize(Database db);
}
```

### Connection

This class implements the `IConnection` interface and provides methods for managing and initializing database connections. It adheres to the Singleton pattern to guarantee a single instance.

```csharp
public class Connection : IConnection
{
    public static Connection Instance { get; } = new Connection();
    public IDbConnection Get { get; private set; }
    public DatabaseType DbType { get; set; }
    public IDbConnection Initialize(Database db);
}
```

### DatabaseType

This enumeration specifies the supported database types.

```csharp
public enum DatabaseType
{
    MySql,
    SqlServer,
    PostgreSql,
    Oracle
}
```

## Contact

For any inquiries or suggestions, feel free to contact at ardinbig@gmail.com.
