using ApiCatalogo.ApiEndpoints;
using ApiCatalogo.AppServicesExtensions;
using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();


var app = builder.Build();

//endpoint para login

app.MapAutenticacaoEndpoint();


// endpoints categoria

app.MapCategoriasEndpoints();

//endpoints produto

app.MapProdutosEndpoints();

// Configure the HTTP request pipeline.
var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();
app.Run();

