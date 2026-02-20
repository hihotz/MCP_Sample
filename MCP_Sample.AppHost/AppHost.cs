var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MCP_Sample>("mcp-sample");

builder.Build().Run();
