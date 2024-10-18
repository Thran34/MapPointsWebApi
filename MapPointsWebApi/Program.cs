namespace MapPointsWebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                corsBuilder => corsBuilder
                    .WithOrigins("http://localhost:8000") // Your frontend origin
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Apply the CORS policy
        app.UseCors("AllowSpecificOrigin");

        app.UseAuthorization();

        app.MapGroup($"/api/Point")
            .WithGroupName("Point")
            .WithTags("Point")
            .WithOpenApi();
        
        app.MapControllers();
        app.Run();
    }
}