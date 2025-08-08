using BoneConnect.Middlewares;
using BoneConnect.Settings.Authentication;
using BoneConnect.Settings.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCustomServices();


builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowCredentials().AllowAnyHeader().AllowAnyMethod()
    .SetIsOriginAllowed(x => true));
app.UseMiddleware<SanitizationMiddleware>();

app.Run();


namespace BoneConnect
{
    public class Program
    {
    }
}