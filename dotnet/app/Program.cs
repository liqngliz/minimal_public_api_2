var builder = WebApplication.CreateBuilder(args);


var  MyAllowOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowOrigins,
                      policy  =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();
app.UseCors(MyAllowOrigins);

app.MapGet("/", (HttpContext httpContext) => {
    return "cors";
    });


app.MapPost("/", (HttpContext httpContext) => {
    return "cors";
    });

app.Run();
