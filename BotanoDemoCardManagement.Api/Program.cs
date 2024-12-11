using BotanoDemoCardManagement.Api.Middlewares;
using BotanoDemoCardManagement.Application;
using BotanoDemoCardManagement.Persistence;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

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