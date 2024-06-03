using Microsoft.EntityFrameworkCore;
using Sistema_Rodonaves.Data;
using Sistema_Rodonaves.Repository;
using Sistema_Rodonaves.Repository.Interfaces;
using System.Text.Json.Serialization;

namespace Sistema_Rodonaves
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();

            // RETORNO MAIOR
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Api_Crud_CsharpContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );


            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();


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
