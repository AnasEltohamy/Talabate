
using DomainLayer.Contract;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace E_Commerce.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Builder Phase

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
            });
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();




            #endregion

            





            var app = builder.Build();





            #region Pipeline Phase

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using var Scop = app.Services.CreateScope();
            Scop.ServiceProvider.GetRequiredService<IDataSeeding>().DataSeed();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();




            #endregion






            app.Run();
        }
    }
}
