﻿var builder = DistributedApplication.CreateBuilder(args);

//Datastore
var passwordParameter = builder.CreateStablePassword("sqlpassword", minLower: 1, minUpper: 1, minNumeric: 1);
var sqlDatabase = builder.AddSqlServer("sqlserver", passwordParameter)
    .WithDataVolume()
    .AddDatabase("sqldb");

var weatherApi = builder.AddProject<Projects.AspireJavaScript_MinimalApi>("weatherapi")
    .WithReference(sqlDatabase)
    .WithExternalHttpEndpoints();

builder.AddNpmApp("angular", "../PersonalChef.Client.Web")
    .WithReference(sqlDatabase)
    .WithReference(weatherApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.AddProject<Projects.DatabaseMigrations_MigrationService>("migration")
       .WithReference(sqlDatabase);

builder.Build().Run();