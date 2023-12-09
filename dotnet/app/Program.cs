using System.Collections.Specialized;
using System.Web;

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


app.MapPost("/", async (HttpContext httpContext) => {
    string body;

    using (StreamReader reader = new StreamReader (httpContext.Request.Body)) {
        body = await reader.ReadToEndAsync ();
    }
    
    return body;
    });

app.Run();
