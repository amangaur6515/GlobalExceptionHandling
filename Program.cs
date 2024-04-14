using GlobalExceptionHandling.CustomMiddleware;
using GlobalExceptionHandling.Services;
using Microsoft.Extensions.Logging;

namespace GlobalExceptionHandling
{
    // Blog LINK
    // https://code-maze.com/global-error-handling-aspnetcore/
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICustomException, CustomException>();

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
            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            

            app.Run();
        }
    }
}
