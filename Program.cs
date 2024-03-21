using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NS.Core.API.Extensions;
using NS.Core.API.MiddleWare;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString(Constants.AppSettingKeys.DEFAULT_CONNECTION)));
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "NS.Core API", Version = "v1" });
    option.CustomSchemaIds(type => type.ToString());
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<ExceptionHandlerMiddleWare>();
builder.Services.AddTransient<JwtMiddleWare>();
builder.Services.ServiceRegister();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDbMigration();
app.UseDataSeeding();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDataSeeding(true);
}
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseMiddleware<JwtMiddleWare>();
app.UseAuthorization();

app.MapControllers();

app.Run();
