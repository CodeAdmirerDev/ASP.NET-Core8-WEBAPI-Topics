
using WebAPISampleProjectWIthVS2022.Models.RepositoryPattren;

namespace WebAPISampleProjectWIthVS2022
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

            // Regiser the EmpRepository class with the DI container
            builder.Services.AddSingleton<IEmpRepository, EmpRepository>();
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

            //Conventional based routing example
            app.MapControllerRoute(
                name: "default",
                pattern: "api/{controller}/{action}/{id?}"
                );

            app.Run();
        }
    }
}
