using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApiFridges.Data;
using WebApiFridges.Models;
using WebApiFridges.MyIntefaces;
using WebApiFridges.Repository;
namespace WebApiFridges
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //-------------
            builder.Services.AddScoped<IFridgeRepository, FridgeRepository>(); // одно внедрение на весь запрос
            builder.Services.AddScoped<IFridgeProductsRepository, FridgeProductsRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

			// CORS service addition
			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
				{
					builder.AllowAnyOrigin()
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				});
			});
			//-------------

			var app = builder.Build();

			// activation CORS
			app.UseCors();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();  // задействует контроллеры

            app.Run();
        }
    }
}
