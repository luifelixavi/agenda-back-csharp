using Agenda.API.Configuration;
using Agenda.API.Configuration.Model;
using Agenda.API.Domain.Model;
using AutoMapper;
using Core.Util.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("Database"));


builder.Services.AddApiConfiguration();

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ResolveDependencies();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthConfiguration();

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
