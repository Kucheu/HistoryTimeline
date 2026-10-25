using Api.Endpoints;
using Infrastructure;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddServices().AddValidators().AddExceptionHandler();

builder.Services.AddHistoryTimelineDbContext(builder.Configuration).AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Api");
    });
}

app.MapDefaultEndpoints();
app.MapHistoryEventsEndpoints();
app.MapHistoryEventsLevelOfDetail();

app.UseFileServer();

app.Run();
