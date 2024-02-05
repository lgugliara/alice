# ALICE API Module

*Note: To scaffold CRUD APIs for all models in a folder, you can use an iterative approach combined with a shell script or a shell command. See below.*

## Installation

**Create a new Minimal API project:**

```bash
dotnet new web -n ProjectName
```

This command creates a new ASP.NET web project with the basic structure in the "ProjectName" folder. Make sure you are in the folder where you want to create the project.

Add a reference to the class library project (Entity Framework):

```bash
dotnet add reference ../LibraryName/LibraryName.csproj
```

Replace "../LibraryName/LibraryName.csproj" with the correct path to your class library project file (where you defined the EF entities).

**Scaffold CRUD APIs:**

To list all the entities in a folder, you can run the following command:

```bash
# Make sure you are in the project folder
cd ProjectName

# List all entities in the Models folder (assuming models are .cs files)
models=$(find Models -name "*.cs" -exec basename {} \; | sed 's/\.cs$//')
```

To create minimal APIs from Entity Framework (EF) entities using an ASP.NET Core Minimal API project, follow these steps:

Use the `dotnet aspnet-codegenerator` command to scaffold CRUD APIs based on your EF database context and entities.

```bash
dotnet aspnet-codegenerator controller -name EntityController -m Entity -dc YourDbContext --relativeFolderPath Controllers
```

Ensure you replace "EntityController" with the desired name for the controller and "Entity" with the name of the entity for which you want to create APIs. "YourDbContext" should be replaced with the actual name of your EF DbContext.

Alternatively, you can automatically iterate over the list of entities and scaffold CRUD APIs:

```bash
# Iterate over the list of entities
for model in $models
do
    # Scaffold CRUD APIs for each entity
    dotnet aspnet-codegenerator controller -name "${model}Controller" -m $model -dc YourDbContext --relativeFolderPath Controllers
done
```

Make sure to replace "YourDbContext" with the actual name of your EF DbContext. This script creates a controller for each model in the Models folder.

**Run the project:**

```bash
dotnet run
```

Now you should have an ASP.NET Core Minimal API project with CRUD APIs automatically generated based on your Entity Framework entities. You can test the APIs using tools like Postman or Swagger UI.