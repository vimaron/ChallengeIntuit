using ChallengeIntuit.Services;
using Data;
using Data.Repository;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigin = "";
            var builder = WebApplication.CreateBuilder(args);
            ApplicationDbContext.ConnectionString = builder.Configuration.GetConnectionString("IntuitChallege");
            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigin,
                    options =>
                    {
                        options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                    });
            });

            builder.Services.AddScoped<ClientsService>();

            builder.Services.AddScoped(typeof(ClientsRepository));

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var loggerFactory = app.Services.GetService<ILoggerFactory>();
            loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigin);

            app.MapControllers();

            app.Run();

        }
    }
}
