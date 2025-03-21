
using AutoMapperUsageInWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperUsageInWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().
            AddJsonOptions(options =>
            {
                // Configure the JSON serializer options to keep orignal names in serialized and deserilized JSON
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

            });

            //Registering AutoMapper  (It will scans the assembly for Profile)
            //This scans  the assembly contaings program class for any classes inheriting the Profiles and it will register them automatically

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register the DbContext with the connection string
            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("EcommorceConfig"));
            });

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
        }
    }
}
