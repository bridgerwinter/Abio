using Microsoft.EntityFrameworkCore;
using System;
using Abio.Library.DatabaseModels;
using InstantAPIs;
using Abio.WS.Hubs;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AbioContext>(
   options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSqlServer<AbioContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSignalR(opts =>
{
    opts.EnableDetailedErrors = true;
    opts.MaximumReceiveMessageSize = 100000;
})
    .AddNewtonsoftJsonProtocol(opts => opts.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto);
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
app.MapDefaultControllerRoute();
app.MapHub<ChatHub>("/chatHub");
app.MapHub<CombatHub>("/combatHub");
app.MapHub<ConstructionHub>("/constructionHub");
app.Run();
