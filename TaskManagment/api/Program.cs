using infrastructure;
using infrastructure.repositories;
using service.services;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddNpgsqlDataSource(Utilities.devConnectionString,
        dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());
}

builder.Services.AddNpgsqlDataSource(Utilities.connectionString);

builder.Services.AddSingleton<TaskService>();
builder.Services.AddSingleton<TaskRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => {
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();

