using AbsenseApi.DBContext;
using AbsenseApi.Secret;
using AbsenseApi.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentLibrary;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
           {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});
builder.Services.AddDbContext<StudentContext>(opt => opt.UseSqlServer(Secret.connectionstring));
builder.Services.AddTransient<DBService<Student>, DBService<Student>>();


builder.Services.AddControllers();
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

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();





