using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RestApi_MongoDB.Database;
using RestApi_MongoDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<UserManagementStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(UserManagementStoreDatabaseSettings)));
builder.Services.AddSingleton<IUserManagementStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<UserManagementStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient());

builder.Services.AddSingleton<IUserService, UserService>();

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