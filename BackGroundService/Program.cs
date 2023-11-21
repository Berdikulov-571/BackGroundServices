
using BackGroundService.Services.HostedServices;

namespace BackGroundService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Registration Hosted Services
            builder.Services.AddHostedService<HostedService>();

            // Configuration Our Hosted Services
            builder.Services.Configure<HostOptions>(options =>
            {
                // Errorlarni ignore qilib yuboradi
                options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
                // Agar shu vaqt ichida dastur ishga tushmasa cancel qilib yuboradi
                //options.StartupTimeout = TimeSpan.FromSeconds(10);
                // Agar shu vaqt ichida dastur o'chmasa cancel qilib yuboradi
                //options.ShutdownTimeout = TimeSpan.FromSeconds(10);

                // Bu start Functiondagi kutishni olib tashlaydi yani ignore qilib yuboradi
                options.ServicesStartConcurrently = true;
                options.ServicesStopConcurrently = true;
            });

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
