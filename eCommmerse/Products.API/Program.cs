using Products.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Add DEL and BLL services
builder.Services
    .AddDataAccessLayer(builder.Configuration);

builder.Services.AddBusinessLayer();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddSingleton<ExceptionHandlingMiddleware>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();