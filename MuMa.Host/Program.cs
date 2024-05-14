
using Microsoft.EntityFrameworkCore;
using MuMa.Domain.Repositories;
using MuMa.EntityFramework;
using MuMa.EntityFramework.Repositories;
using AutoMapper;
using MuMa.Authorization.Controllers;

namespace MuMa.Host
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

            builder.Services.AddAutoMapper(typeof(ListenerProfile));
            builder.Services.AddDbContext<MuMaDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings")["Default"]);
            });

            UseDependencyInjection(builder.Services);

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

        private static void UseDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<MuMaDbContext>();
            services.AddTransient<IListenerRepository, ListenerRepository>();
        }
    }
}
