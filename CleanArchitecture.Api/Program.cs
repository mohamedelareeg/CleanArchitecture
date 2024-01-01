using CleanArchitecture.Api.Configuration.Extensions.Swagger;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Middleware;
using CleanArchitecture.Identity;
using CleanArchitecture.Infrustructure;
using CleanArchitecture.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
//Serilog
Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Services.AddSerilog();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

//Register Dependencies
builder.Services.AddApplicationDependencies(builder.Configuration)
                .AddInfrustructureDependencies(builder.Configuration)
                .AddPersistenceDependencies(builder.Configuration)
                .AddIdentityDependencies(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();


////////////////////////////////////////////////////////Localizer with JSON//////////////////////////////////////
var supportedCultures = new[] { "en-US", "ar-EG", "de-DE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
localizationOptions.ApplyCurrentCultureToResponseHeaders = true;
app.UseRequestLocalization(localizationOptions);


app.UseRouting();
////////////////////////////////////////////////////////END//////////////////////////////////////////////////////
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
