using managementtaskexercice.Authentication.Extensions.Authentication;
using managementtaskexercice.Persistence.Repositories;
using managementtaskexercice.Authentication.Extensions.Session;
using managementtaskexercice.Authentication.Extensions.Authorization;
using managementtaskexercice.Authentication.Token;
using managementtaskexercice.Application.Contracts.Persistence;
using managementtaskexercice.Persistence;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Authentication;
using Microsoft.AspNetCore.Identity;
using managementtaskexercice.Application.Contracts.Specifications;
using managementtaskexercice.Application.Specifications.MTask;
using managementtaskexercice.Application.Contracts.Tasks.Filter;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Task.Filter;
using managementtaskexercice.Application.Contracts.Tasks.Pagination;
using managementtaskexercice.Task.Pagination;
using managementtaskexercice.Task.Sorting;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationExtension();
builder.Services.AddControllers();
builder.Services.Authorization();
builder.Services.AddToken();
builder.Services.Session();
//builder.Services.AddScoped<IAsyncRepository<MTask>, BaseRepository<MTask>>();
builder.Services.AddScoped<IAsyncTaskRepository, MtaskRepository>();
builder.Services.AddScoped<IAsyncUserRepository, UserRepository>();
builder.Services.AddScoped<IAsyncFilter<UserTasks>, FilterRepository>();
builder.Services.AddScoped<IUpdateTaskSpecification, UpdateTaskSpecification>();
builder.Services.AddScoped<IPagination, PagingRepository>();
builder.Services.AddScoped<SortingRepository,SortingRepository>();
//builder.Services.AddScoped<UserRepository>();

builder.Services.AddDbContext<ManagementtaskDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDistributedMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
 options.SwaggerDoc("v1", new OpenApiInfo
 {
     Version = "v1",
     Title = "Management Task  API",
     Description = "An ASP.NET Core Web API for managing Task"
    
 }));
/*builder.Logging.AddJsonConsole(options=>

options.JsonWriterOptions= new(){
    Indented = true
}
);*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();

app.Run();
