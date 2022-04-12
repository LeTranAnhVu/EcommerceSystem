using Api.Filters;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


// Add services to the container.
var useInMem = builder.Configuration.GetValue<bool>("UseInMemDb");
var conn = builder.Configuration.GetValue<string>("ConnectionString");

services.AddInfrastructure( new InfrastructureDIOptions{ UseInMemDb = useInMem, ConnectionString = conn});

services.AddApplication();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorHandlerActionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();