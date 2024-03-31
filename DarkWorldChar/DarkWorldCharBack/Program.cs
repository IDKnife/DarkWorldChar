using DarkWorldChar.Backend.Middlewares;
using DarkWorldChar.Repositories;
using DarkWorldChar.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;

namespace DarkWorldChar.Backend
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var connectionString = builder.Configuration.GetConnectionString("Mongo");
			var connection = new MongoUrlBuilder(connectionString);
			var client = new MongoClient(connectionString);
			builder.Services.AddSingleton(client.GetDatabase(connection.DatabaseName));
			builder.Services.AddCors(o => o.AddPolicy("DefaultPolicy", policyBuilder =>
			{
				policyBuilder
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowAnyOrigin();
			}));

			builder.Services
				.AddRepositories()
				.AddServices();

			builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			var app = builder.Build();

			app.UseCors();
			app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

			// Configure the HTTP request pipeline.
			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}