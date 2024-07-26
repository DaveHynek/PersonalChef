---
languages:
- csharp
products:
- dotnet
- dotnet-aspire
page_type: sample
name: "Database migrations with Entity Framework Core sample app"
urlFragment: "aspire-efcore-migrations"
description: "A sample of using Entity Framework Core database migrations feature to update a database schema."
---

# PersonalChef

## Sample prerequisites

This sample is written in C# and targets .NET 8.0. It requires the [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later.

## Create migration

The `DatabaseMigrations.MigrationService` project contains the EF Core migrations. The [`dotnet ef` command-line tool](https://learn.microsoft.com/ef/core/managing-schemas/migrations/#install-the-tools) can be used to create new migrations:

1. Update the `Entry` entity in database context in `MyDb1Context.cs`. Add a `Name` property:

    ```cs
    public class Entry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
    }
    ```

2. Open a command prompt in the `DatabaseMigrations.MigrationService` directory and run the EF Core migration tool to create a migration named **MyNewMigration**.

    ```bash
    dotnet ef migrations add MyNewMigration
    ```

    The preceding command:

      - Runs EF Core migration command-line tool in the `DatabaseMigrations.MigrationService` directory.
        - `dotnet ef` is run in this location because it will be used as the default target project for the new migration and the tool will run the startup code in `Program.cs` to find and configure the context to be used.
      - Creates the migration named `MyNewMigration` in the `DatabaseMigrations.MigrationService` project.

3. View the new migration files in the `DatabaseMigrations.ApiModel` project.

> [!NOTE]
> To remove the unapplied migration you need to run `dotnet ef migrations remove --force`.  The `--force` switch tells the tool to avoid connecting to the database

## Run the app

1. If using Visual Studio, open the solution file `PersonalChef.sln` and launch/debug the `PersonalChef.AppHost` project.

    * If using the .NET CLI, run `dotnet run` from the `DatabaseContainers.AppHost` directory.

1. The first time you run the app, you'll receieve an error indicating that a password for the SQL Server container has not been configured. To configure a password, set the `sqlpassword` key in the User Secrets store of the `PersonalChef.AppHost` project using the `dotnet user-secrets` command in the AppHost project directory:

    ```
    dotnet user-secrets set sqlpassword <password>
    ```

    A stable password is required when using a persistent volume mount for SQL Server data, rather than the default auto-generated password.

When the app starts up, the `DatabaseMigrations.MigrationService` background worker runs migrations on the SQL Server container. The migration service:

- Creates a database in the SQL Server container.
- Creates the database schema.
- Stops itself once the migration is complete.
