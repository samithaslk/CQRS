using Dot7.Architecture.Api.Extensions;
using Dot7.Architecture.Application;
using Dot7.Architecture.Application.Authenticate.Services;
using Dot7.Architecture.Application.Log;
using Dot7.Architecture.Infrastructure;
using Dot7.Architecture.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using VueCliMiddleware;

var builder = WebApplication.CreateBuilder(args); 
builder.Host.UseSerilog((context, loggerConfig) => {
    loggerConfig
    .ReadFrom.Configuration(context.Configuration)
    .Enrich.FromLogContext()
     .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341");
});


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});

//LogManager.Setup().LoadConfigurationFromFile("/nlog.config");
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureInfraStructure(builder.Configuration);
builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IConfigurationSettingsService, ConfigurationSettingsService>();
builder.Services.AddDbContext<MyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));

var key = WebApplication.CreateBuilder().Configuration["Settings:AccessTokenKey"];
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(config => {
    config.RootPath = "ClientApp";
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.UseSerilogRequestLogging();
app.ConfigureExceptionHandler(logger);
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment; 
 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(builder => builder
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowAnyOrigin()
   );
app.UseSpaStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers(); 

app.Run();
