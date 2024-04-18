using Contacts.Api;
using Contacts.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Contacts.Api.Endpointns;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>

            options.AddPolicy("AllowReactApp",
                builder =>
                builder.WithOrigins("http://localhost:3000") // React uygulamanızın URL'sini buraya ekleyin
                        .AllowAnyHeader()
                         .AllowAnyMethod()));
var connection = builder.Configuration.GetConnectionString("Contacts");
builder.Services.AddSqlServer<DirectoryContex>(connection);
var app = builder.Build();
app.UseCors("AllowReactApp");
app.MapPersonsEndPoints();
await app.MigrateAsync();
app.Run();
