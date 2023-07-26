using Microsoft.EntityFrameworkCore;
using System;
using InstantAPIs;
using Abio.WS.API.DatabaseModels;

var builder = WebApplication.CreateBuilder(args);
/////
///TRY AUTOREST NEXT
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Abio.WS.API.DatabaseModels.AbioContext>(
   options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSqlServer<Abio.WS.API.DatabaseModels.AbioContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddInstantAPIs();

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
