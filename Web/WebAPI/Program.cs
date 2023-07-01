using WebAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.AddStartupServices();
var app = builder.Build();
app.BuildAndRun();
