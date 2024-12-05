var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DebercBackend_Web>("web");

builder.Build().Run();
