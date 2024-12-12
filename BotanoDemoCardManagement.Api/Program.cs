using BotanoDemoCardManagement.Api.Middlewares;
using BotanoDemoCardManagement.Application;
using BotanoDemoCardManagement.Persistence;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceService(builder.Configuration);

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition(
        name: "Bearer",
        securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description =
                "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer YOUR_TOKEN\". \r\n\r\n"
                + "`Enter your token in the text input below.`"
        }
    );
    opt.OperationFilter<BearerSecurityRequirementOperationFilter>();

    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Card Management API",
        Description = "This project was developed as part of the Botano Technologies recruitment process.",
        Contact = new OpenApiContact
        {
            Name = "Botano Technologies ",
            Email = "admin@botano.com",
            Url = new Uri("https://botano.com/"),
            
        }

    });
    // XML yorumlarý eklemek için
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.DocExpansion(DocExpansion.None);
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();