
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

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





            #endregion

            





            var app = builder.Build();





            #region Pipeline Phase





            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();




            #endregion






            app.Run();
        }
    }
}
