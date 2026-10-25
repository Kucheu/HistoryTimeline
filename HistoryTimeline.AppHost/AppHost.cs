var builder = DistributedApplication.CreateBuilder(args);

var historyTimelineApi = builder.AddProject<Projects.HistoryTimeline_Server>("historyTimelineApi");

var webfrontend = builder.AddProject<Projects.MudBlazorFrontend>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(historyTimelineApi)
    .WaitFor(historyTimelineApi);

builder.Build().Run();
