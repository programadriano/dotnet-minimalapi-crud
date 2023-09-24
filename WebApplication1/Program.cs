
using Microsoft.OpenApi.Models;
using StocksAPI.Models;

namespace StocksAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Stocks API",
                    Version = "v1",
                    Description = "Descrição da Sua API",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago S Adriano",
                        Email = "prof.thiagoadriano@teste.com",
                    }
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            var stocks = new List<Stock>();


            app.MapGet("/stocks", () => stocks)
                .CacheOutput(policy =>
                {
                    policy.SetVaryByRouteValue("param");
                    policy.Expire(TimeSpan.FromMinutes(10));
                });

            app.MapGet("/stocks/{id}", (int id) => stocks.FirstOrDefault(sa => sa.Id == id))
                .CacheOutput(policy =>
            {
                policy.Expire(TimeSpan.FromMinutes(10));
            });


            app.MapPost("/stocks", (Stock stockActivity) =>
            {
                stockActivity.Id = stocks.Count + 1;
                stocks.Add(stockActivity);
                return Results.Created($"/stocks/{stockActivity.Id}", stockActivity);
            });

            app.MapPut("/stocks/{id}", (int id, Stock stockActivity) =>
            {
                var existingActivity = stocks.FirstOrDefault(sa => sa.Id == id);
                if (existingActivity != null)
                {
                    existingActivity.Symbol = stockActivity.Symbol;
                    existingActivity.Action = stockActivity.Action;
                    existingActivity.Quantity = stockActivity.Quantity;
                    return Results.NoContent();
                }
                return Results.NotFound();
            });

            app.MapDelete("/stocks/{id}", (int id) =>
            {
                var existingActivity = stocks.FirstOrDefault(sa => sa.Id == id);
                if (existingActivity != null)
                {
                    stocks.Remove(existingActivity);
                    return Results.NoContent();
                }
                return Results.NotFound();
            });

            app.Run();
        }
    }
}
