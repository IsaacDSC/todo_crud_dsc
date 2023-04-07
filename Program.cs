var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware");
    await next(context);
});


app.MapControllers();

// app.Run(async context =>
// {
//     context.Response.StatusCode = 404;
//     await context.Response.WriteAsync("{\"message\": \"Not Found Router\"}");
// });

app.Run();
