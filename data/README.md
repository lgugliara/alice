# ALICE Data Module

## About

You can create a class library using the command line. For instance, you can run the following command to create a .NET Standard 2.0 class library:

    dotnet new classlib -n LibraryName

This command creates a new class library named "LibraryName" with the basic structure.

**Publish the library**
   
If you plan to publish the library, you can do so using the publish command. Make sure to properly configure the project file to indicate the desired publish options.

    dotnet publish -c Release

These steps will help you create a C# class library with .NET 8. Be sure to adapt the commands and options to your specific project needs.

To set up Entity Framework with SQLite within a class library project (.NET Standard/.NET Core), you can follow these steps:

## Installation

To create the SQLite database in your project, you can follow these steps.

*Make sure to replace `"Data Source=alicedata.db"` with the desired path for your SQLite database.*

**Package Installation**

```bash
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

**Defining a new DbContext**

To scaffold the entities and the database context without writing code, you can use the `dotnet ef dbcontext scaffold` command, providing your database connection string and specifying the database provider (SQLite in your case).

```bash
dotnet ef dbcontext scaffold "Data Source=alicedata.db" Microsoft.EntityFrameworkCore.Sqlite -o Models
```

In this command:

- `"Data Source=alicedata.db"` is your SQLite database connection string.
- `Microsoft.EntityFrameworkCore.Sqlite` specifies the SQLite database provider.
- `-o models` indicates that the generated classes should be placed in the `models` folder.

This command will use Entity Framework to inspect your existing database and automatically generate entity classes and the database context based on the database schema.

**Run the migration to create the database:**

After configuring the DbContext, you can run the migration command to apply the database schema:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The first command creates an initial migration, and the second actually updates the database.

Now you should have an SQLite database created and ready for use in your project. You can start interacting with the database using the generated entities and DbContext.

## Usage

**Editing the schema**

To add new tables to the `app.db` database through a migration in Entity Framework, follow these steps:

**Create a New Entity:**
If you want to add a new table, you need to define a new entity class representing the structure of the table. For example, if you're creating a `Product` table, create a `Product` class in your DbContext.

```csharp
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    // Other properties...
}
```

**Add DbSet to DbContext:**
In your DbContext class, add a `DbSet` property for the new entity.

```csharp
public class YourDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    // Other DbSet properties...
}
```

**Create a Migration:**
Run the following command in the terminal to create a new migration:

```bash
dotnet ef migrations add AddProductTable
```

Replace `AddProductTable` with a meaningful name for your migration.

**Apply the Migration:**
After creating the migration, apply it to update the database:

```bash
dotnet ef database update
```

This command will apply the pending migrations and update the database schema.

Now, you should have a new table (`Product` in this example) added to the `app.db` database. Repeat these steps for each new table you want to add, creating a new entity class, updating the DbContext, creating a migration, and applying the migration.

Remember to replace `YourDbContext` with the actual name of your DbContext class.

**Applying migrations:**

Apply migrations to create the SQLite database:

```bash
dotnet ef database update
```

This command will apply any pending migrations and create your SQLite database.

[About editing the schema](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)