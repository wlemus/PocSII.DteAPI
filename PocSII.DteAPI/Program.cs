
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using PocSII.DteAPI.Common;
using PocSII.DteAPIApplicacion.Common;
using PocSII.DteAPIApplicacion.Interfaces;
using PocSII.DteAPIApplicacion.Mappings;
using PocSII.DteAPIApplicacion.Services;
using PocSII.DteBusinessRules.Interfaces;
using PocSII.DteProcessor.Services;
using System.Text;

namespace PocSII.DteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            #region Dependencias
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IDocumentService, InvoiceService>();
            builder.Services.AddScoped<DocumentServiceFactory>();
            builder.Services.AddHttpClient<DteSenderService>();
             builder.Services.AddScoped<IProcessDocumentService, ProcessDTEService>();
            #endregion


            var appSettingsSection = builder.Configuration.GetSection("AppSettings");
            builder.Services.Configure<AppSettings>(appSettingsSection);

            //JWT Authentication
            #region JWT Authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            builder.Services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x => { 
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            #endregion



            // Configurar AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfile));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            #region Environment Variable
            var siiSettingsSection = builder.Configuration.GetSection("SiiSettings");
            var siiSettings = siiSettingsSection.Get<SiiSettings>();

            Environment.SetEnvironmentVariable("SII_ENDPOINT_ENVIO", siiSettings.SendEndpoint);
            Environment.SetEnvironmentVariable("SII_ENDPOINT_CONSULTA", siiSettings.GetEndpoint);
            #endregion
            //Log de errores
            #region logger
            builder.Services.AddLogging(loggingBuilder => {              
                loggingBuilder.AddConsole();
            });
            //Capturar excepciones no controladas
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

                    logger.LogError(exceptionHandlerPathFeature?.Error, "Excepció no controlada");

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsJsonAsync(new { error = "Ocurrió un error inesperado." });
                });
            });
            #endregion
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
